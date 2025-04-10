using System.Globalization;
using System.Text.RegularExpressions;
using Application.Gifts.Queries.ScrapeGiftDetails;
using HtmlAgilityPack;
using Schema.NET;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Infrastructure.Services;

public partial class GiftScrapingService : IGiftScrapingService
{
    public async Task<GiftDetails> ScrapeGiftDetailsAsync(string url)
    {
        var web = new HtmlWeb();
        var doc = await web.LoadFromWebAsync(url);

        // Select the script node containing the Product schema https://schema.org/Product
        var productSchemaNode = doc.DocumentNode.SelectSingleNode("//script[@type='application/ld+json' and contains(text(), 'offers')]");
        if (productSchemaNode == null)
        {
            return GiftDetails.Empty;
        }
        
        // Prepare the JSON string for deserialization by removing extra whitespaces
        var productSchemaJson = WhitespaceRegex().Replace(productSchemaNode.InnerText, " ");
        var product = JsonSerializer.Deserialize<Product>(productSchemaJson);
        if (product == null)
        {
            return GiftDetails.Empty;
        }
        
        var name = product.Name.FirstOrDefault() ?? string.Empty;
        var price = ExtractPriceFromProduct(product);
        var currency = ExtractCurrencyFromProduct(product);
        var imageUrl = ExtractImageUrlFromProduct(product, url);

        return new GiftDetails(name, price, currency, imageUrl);
    }

    private static decimal? ExtractPriceFromProduct(IProduct product)
    {
        // Check if the product has any IOffer values
        if (!product.Offers.HasValue2)
        {
            return decimal.Zero;
        }
        
        var offer = product.Offers.Value2.FirstOrDefault();
        if (offer == null)
        {
            return decimal.Zero;
        }
        
        // Extract the price from the decimal value
        if (offer.Price.HasValue1)
        {
            return offer.Price.Value1.First();
        }

        // Extract and parse the price from the string value
        if (offer.Price.HasValue2)
        {
            var priceString = offer.Price.Value2.FirstOrDefault();
            if (decimal.TryParse(priceString, NumberStyles.Any, CultureInfo.InvariantCulture, out var price))
            {
                return price;
            }
        }
        
        return decimal.Zero;
    }
    
    private static string ExtractCurrencyFromProduct(IProduct product)
    {
        // Check if the product has any IOffer values
        if (!product.Offers.HasValue2)
        {
            return string.Empty;
        }
        
        var offer = product.Offers.Value2.FirstOrDefault();
        return offer?.PriceCurrency.FirstOrDefault() ?? string.Empty;
    }
    
    private static string ExtractImageUrlFromProduct(IProduct product, string sourceUrl)
    {
        // Check if the product has any Uri values
        if (!product.Image.HasValue2)
        {
            return string.Empty;
        }
        
        var imageUrl = product.Image.Value2.FirstOrDefault()?.ToString() ?? string.Empty;
        
        // If the URL is not absolute, append the host from the original URL
        if (!string.IsNullOrEmpty(imageUrl) && !Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
        {
            var baseUri = new Uri(sourceUrl);
            imageUrl = new Uri(baseUri, imageUrl).ToString();
        }

        return imageUrl;
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex WhitespaceRegex();
}
