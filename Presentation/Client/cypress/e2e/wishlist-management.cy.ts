describe('Wishlists Library', () => {
  beforeEach(() => {
    cy.viewport(1536, 960)
    cy.intercept('GET', '**/wishlists?*', { fixture: 'wishlists.json' }).as('getWishlists');
    cy.intercept('DELETE', '**/wishlists/*', { statusCode: 200 }).as('deleteWishlist');
    cy.intercept('PUT', '**/wishlists/*', { statusCode: 200 }).as('editWishlist');

    cy.visit('/wishlists/library');
  });

  it('Повинен завантажувати та відображати вішлісти', () => {
    cy.wait('@getWishlists');
    cy.get('.wishlists app-wishlist-card').should('have.length', 2);
  });

  it('Повинен відкрити модальне вікно при натисканні на кнопку створення вішліста', () => {
    cy.get('.create-card').click();
    cy.get('.modal-header p').should('contain', 'Create Wishlist');
  });

  it('Користувач може створити новий вішліст', () => {
    cy.intercept('POST', '**/wishlists', { statusCode: 201 }).as('createWishlist');

    cy.get('.create-card').click();
    cy.get('#name').type('New Wishlist');
    cy.get('.custom-radio-field').first().click();
    cy.get('.category').first().click();
    cy.get('button.accent').click();

    cy.wait('@createWishlist');
    cy.get('.modal-header').should('not.exist');
  });

  it('Повинен завантажувати та відображати вішлісти', () => {
    cy.wait('@getWishlists');
    cy.get('.wishlists app-wishlist-card').should('have.length', 2);
  });

  it('Користувач може видалити вішліст', () => {
    cy.get('.wishlists app-wishlist-card').first().within(() => {
      cy.get('.actions-menu-button').click();
      cy.get('.actions-menu button').contains('Remove').click();
    });
    cy.wait('@deleteWishlist');
    cy.get('.wishlists app-wishlist-card').should('have.length', 1);
  });

  it('Користувач може обрати до 3 категорій', () => {
    cy.get('.create-card').click();

    cy.get('.category').eq(0).click();
    cy.get('.category').eq(1).click();
    cy.get('.category').eq(2).click();
    cy.get('.category').eq(3).should('not.have.class', 'selected');
  });


});

