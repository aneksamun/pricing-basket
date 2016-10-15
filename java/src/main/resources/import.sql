insert into products (id, name, price) values (1, 'Soup', 0.65);
insert into products (id, name, price) values (2, 'Milk', 1.3);
insert into products (id, name, price) values (3, 'Apples', 1);
insert into products (id, name, price) values (4, 'Bread', 0.8);

insert into offers (id, discount, product_id) values (1, 10, 3);
insert into offers (id, discount, product_id) values (2, 50, 4);

insert into rules (id, offer_id, product_id, amount) values (1, 2, 1, 2);