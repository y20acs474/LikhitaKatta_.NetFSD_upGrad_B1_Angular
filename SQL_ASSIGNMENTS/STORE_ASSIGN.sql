CREATE DATABASE STORE_ASSIGNMENT;
USE STORE_ASSIGNMENT;
SELECT DB_NAME();
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';
CREATE TABLE customers (
customer_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
phone VARCHAR(20),
email VARCHAR(100),
street VARCHAR(100),
city VARCHAR(50),
state VARCHAR(50),
zip_code VARCHAR(10)
);
CREATE TABLE orders (
order_id INT PRIMARY KEY,
customer_id INT,
order_status INT,
order_date DATE,
required_date DATE,
shipped_date DATE,
store_id INT,
staff_id INT
);
CREATE TABLE brands (
brand_id INT PRIMARY KEY,
brand_name VARCHAR(255)
);
CREATE TABLE categories (
category_id INT PRIMARY KEY,
category_name VARCHAR(255)
);
CREATE TABLE products (
product_id INT PRIMARY KEY,
product_name VARCHAR(255),
brand_id INT,
category_id INT,
model_year INT,
list_price DECIMAL(10,2)
);
CREATE TABLE stores (
store_id INT PRIMARY KEY,
store_name VARCHAR(255),
phone VARCHAR(25),
email VARCHAR(255),
street VARCHAR(255),
city VARCHAR(255),
state VARCHAR(50),
zip_code VARCHAR(10)
);
CREATE TABLE order_items (
order_id INT,
item_id INT,
product_id INT,
quantity INT,
list_price DECIMAL(10,2),
discount DECIMAL(4,2),
PRIMARY KEY (order_id, item_id)
);
CREATE TABLE stocks (
store_id INT,
product_id INT,
quantity INT,
PRIMARY KEY (store_id, product_id)
);

INSERT INTO customers VALUES
(1,'John','Doe','1234567890','john@example.com','Street 1','New York','NY','10001'),
(2,'Jane','Smith','9876543210','jane@example.com','Street 2','Chicago','IL','60007'),
(3,'Michael','Brown','5556667777','michael@example.com','Street 3','Dallas','TX','73301'),
(4,'Emily','Davis','2223334444','emily@example.com','Street 4','Seattle','WA','98101');
INSERT INTO brands VALUES
(1,'Trek'),
(2,'Giant'),
(3,'Specialized'),
(4,'Cannondale');
INSERT INTO categories VALUES
(1,'Bikes'),
(2,'Accessories'),
(3,'Clothing');
INSERT INTO products VALUES
(1,'Mountain Bike',1,1,2022,800.00),
(2,'Road Bike',2,1,2023,1200.00),
(3,'Helmet',3,2,2022,150.00),
(4,'Cycling Gloves',4,3,2023,50.00),
(5,'Water Bottle',2,2,2021,20.00);
INSERT INTO stores VALUES
(1,'Downtown Bikes','1112223333','downtown@store.com','Street 1','New York','NY','10001'),
(2,'City Cycle Shop','4445556666','citycycle@store.com','Street 2','Chicago','IL','60007');
INSERT INTO orders VALUES
(101,1,1,'2023-01-10','2023-01-15','2023-01-12',1,1),
(102,2,4,'2023-02-05','2023-02-10','2023-02-07',2,2),
(103,3,4,'2023-03-01','2023-03-06','2023-03-03',1,1),
(104,4,1,'2023-04-12','2023-04-17',NULL,2,2);
INSERT INTO order_items VALUES
(101,1,1,2,800.00,0.10),
(101,2,3,1,150.00,0.00),
(102,1,2,1,1200.00,0.05),
(103,1,1,1,800.00,0.00),
(104,1,4,3,50.00,0.00);
INSERT INTO stocks VALUES
(1,1,20),
(1,2,15),
(1,3,30),
(2,1,10),
(2,4,25),
(2,5,40);


SELECT 
c.first_name,
c.last_name,
o.order_id,
o.order_date,
o.order_status
FROM customers c
INNER JOIN orders o
ON c.customer_id = o.customer_id
WHERE o.order_status = 1
OR o.order_status = 4
ORDER BY o.order_date DESC;


SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
INNER JOIN brands b
ON p.brand_id = b.brand_id
INNER JOIN categories c
ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;


SELECT 
s.store_name,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o
ON s.store_id = o.store_id
INNER JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;

SELECT 
p.product_name,
s.store_name,
st.quantity AS stock_quantity,
SUM(oi.quantity) AS total_sold
FROM stocks st
INNER JOIN products p
ON st.product_id = p.product_id
INNER JOIN stores s
ON st.store_id = s.store_id
LEFT JOIN order_items oi
ON st.product_id = oi.product_id
GROUP BY p.product_name, s.store_name, st.quantity
ORDER BY p.product_name;