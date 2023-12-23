create table admin(
	ad_id int not null primary key,	
	password varchar(50) NOT NULL,
	username varchar(50) NOT NULL,
	
);

CREATE TABLE product(
	product_quantity int NOT NULL,
	product_id int IDENTITY(1,1) NOT NULL,
	product_price float NOT NULL,
	product_name varchar(50) NOT NULL,
	ad_id int NOT NULL,
	type varchar(50) NOT NULL,
	sold int,
	PRIMARY KEY (product_id),
	FOREIGN KEY (ad_id) REFERENCES admin(ad_id),
);

CREATE TABLE customer(
	cust_id int IDENTITY(1,1) NOT NULL,
	fname varchar(50) NOT NULL,
	lname varchar(50) NOT NULL,
	phone varchar(50) NOT NULL,
	address_ varchar(50) NOT NULL,
	ad_id int NULL,
	password varchar(50) NULL,
	username varchar(10) NULL,
	Discount float NULL,
	PRIMARY KEY (cust_id),
	FOREIGN KEY (ad_id) REFERENCES admin(ad_id)
);


CREATE TABLE customerorder(
	order_id int NOT NULL,
	cust_id int NOT NULL,
	product_id int NULL,
	yearr int NULL,
	monthh int NULL,
	dayy int NULL,
	FOREIGN KEY (product_id) REFERENCES product(product_id),
	FOREIGN KEY (cust_id) REFERENCES customer(cust_id) ON DELETE CASCADE,
	PRIMARY KEY (order_id),
);



CREATE TABLE payment(
	day int NOT NULL,
	month int NOT NULL,
	year int NOT NULL,
	pay_id int NOT NULL,
	pay_amount float NOT NULL,
	cust_id int NOT NULL,
	PRIMARY KEY (pay_id),
	FOREIGN KEY (cust_id) REFERENCES customer(cust_id) ON DELETE CASCADE
);



/*
A.
select top 1 product_id, count(product_id) as total from customerorder group by product_id order by total desc

B.
select product_id from product where product_id not in(select product_id from customerorder where monthh=@month

C.
select cust_id from customer where cust_id not in(select cust_id from customerorder where yearr>=2021)

D.
SELECT top 1 SUM(pay_amount)as Total,cust_id FROM payment group by cust_id order by Total desc

E.
select top 1  type,count(type) Total from product group by type order by Total desc

F.
SELECT * FROM product LEFT JOIN (SELECT COUNT(DISTINCT cust_id) total ,product_id FROM customerorder group by product_id)  AS newtable ON product.product_id = newtable.product_id

*/