Start time: 10:45

Present:
Dzengiz
Jimmy
Martin
Tony (at home via discord)
___

``` user-stories
## Description

Some users I want to be able to search for products to find specific items I am interested in.

## Criteria

- [ ] The search field must be visible on all pages
- [ ] The search must work on product name and description
- [ ] The results should show in a list with pagination
- [ ] Max 10 results per page visa
- [ ] Empty search results should display a user-friendly message

## Technical notes

- Implement search functionality with ElasticSearch
- Caching of common search results
- Error handling at timeout

## Definition of Done

- [ ] The code is written and tested
- [ ] Documentation is updated
- [ ] Pull request is created
- [ ] Code review is completed
- [ ] All tests pass
```

11:58 - Created a [Github](https://github.com/DzengiZp/HIW---E-Handel) repository, created a new project called HIW, added our first issue Register. 
11:59 Lunch 
13:28 Created login issue in Github.
14:05 Created the product info issue in Github
14:37 Created the cart issue in Github
14:43 Created all the issues.
15:28 Created all the tables required for this app

### Extra Functionalities:

- Billing address - At register account (optional) and at checkout (compulsory)
- Register is not compulsory when entering the website to browse products
- Update account details, e.g. Address, password
- Be able to remove several amounts of the same product from Cart

### PSQL Database Tables:

```sql
CREATE TABLE IF NOT EXISTS users (
email VARCHAR PRIMARY KEY,
password_hash_salt VARCHAR NOT NULL, --B.Crypt
first_name VARCHAR NOT NULL,
surname VARCHAR NOT NULL,
address VARCHAR NOT NULL,
city_name VARCHAR NOT NULL,
zip_code VARCHAR(6) NOT NULL,
country VARCHAR NOT NULL,
social_security_number VARCHAR(15) NOT NULL
);

CREATE TABLE IF NOT EXISTS products (
id SERIAL PRIMARY KEY,
name VARCHAR NOT NULL,
description VARCHAR DEFAULT 'description missing',
price DECIMAL NOT NULL,
inventory INT DEFAULT 0,
rating DECIMAL(3, 2) CHECK (rating >= 1.00 AND rating <= 5.00)
);

CREATE TABLE IF NOT EXISTS carts (
product_id INT UNIQUE NOT NULL,
user_email VARCHAR NOT NULL,
product_name VARCHAR NOT NULL,
product_price DECIMAL NOT NULL,
product_amount INT NOT NULL,
FOREIGN KEY user_email REFERENCES users(email),
FOREIGN KEY product_id REFERENCES products(id)
);
```

I hereby declare this meeting adjourned. 15:37