describe('Auth Login Page', () => {
  beforeEach(() => {
    cy.viewport(1536, 960)
    cy.visit('/auth/login');
  });

  it('Перевірка наявності основних елементів', () => {
    cy.get('.logo h1').should('contain.text', 'Hoffly');
    cy.get('.bigger').should('contain.text', 'Log in to your account');
    cy.get('input#email').should('be.visible');
    cy.get('input#password').should('be.visible');
    cy.get('button.accent').should('be.visible');
    cy.get('.secondary').should('contain.text', 'Continue with google');
  });

  it('Перевірка відправки форми при натисканні Enter', () => {
    cy.intercept('POST', '/api/auth/login', { statusCode: 200, body: { token: 'fake_token' } });

    cy.get('input#email').type('anna.walter380@gmail.com');
    cy.get('input#password').type('Testing123!{enter}');

    cy.url().should('include', 'wishlists/library');
  });

  it('Перевірка переходу до сторінки відновлення пароля', () => {
    cy.get('a').contains("Reset it now.").should('be.visible').click();
    cy.url().should('include', '/auth/reset-password');
  });

  it('Перевірка логіну з невалідними даними', () => {
    cy.get('input#email').type('wrongemail');
    cy.get('input#password').focus().blur();

    cy.get('.smaller').eq(0).should('contain.text', 'Invalid email address');
    cy.get('.smaller').eq(1).should('contain.text', 'Password is required');

    cy.get('button.accent').should('be.disabled');
  });

  it('Перевірка логіну з помилковими даними', () => {
    cy.get('input#email').type('anna.va@gmail.com');
    cy.get('input#password').type('wrongpass123!');
    cy.get('button.accent').click();

    cy.get('#toast-container .toast-error', {timeout: 1000}).should('exist').and('contain.text', 'Provided credentials are not valid');
  });

  it('Успішний логін', () => {
    cy.intercept('POST', '/api/auth/login', { statusCode: 200, body: { token: 'fake_token' } });

    cy.get('input#email').type('anna.walter380@gmail.com');
    cy.get('input#password').type('Testing123!');
    cy.get('button.accent').click();

    cy.url().should('include', 'wishlists/library');
  });
});
