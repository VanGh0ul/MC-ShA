create database marketplace;

use marketplace;

create table user_role (
	id int unsigned primary key auto_increment,

	name varchar(20)
);

insert into user_role(name)
values ("admin"), ("usual");

create table user (
	id int unsigned primary key auto_increment,
	name varchar (50),
	email varchar(20) unique,
	password varchar(40),
	
	role_id int unsigned,
	index(role_id),
	foreign key (role_id) references user_role(id)
		on delete restrict
		on update restrict,

	reg_date date	
);

create table organization(
	id int unsigned primary key auto_increment,
	name varchar(50),
	index(name),

	about text,
	email varchar(20) unique,
	phone varchar(12),
	avatar blob(4200000),
	reg_date date
);

create table address (
	id int unsigned primary key auto_increment,
	
	organization_id int unsigned,
	index(organization_id),
	foreign key (organization_id) references organization(id)
		on delete restrict
		on update restrict,

	is_deleted bool default false,
	name varchar(50)
);

create table organization_content(
	organization_id int unsigned,
	index(organization_id),
	foreign key (organization_id) references organization(id)
		on delete restrict
		on update restrict,

	user_id int unsigned,
	index(user_id),
	foreign key (user_id) references user(id)
		on delete restrict
		on update restrict,

	unique index(organization_id, user_id)
);

create table measure_unit(
	id int unsigned primary key auto_increment,
	name varchar(30)
);

create table category(
	id int unsigned primary key auto_increment,
	name varchar(30)
);

create table product(
	id int unsigned primary key auto_increment,

	seller_id int unsigned,
	index(seller_id),
	foreign key (seller_id) references organization(id)
		on delete restrict
		on update restrict,

	name varchar(50),
	index(name),

	about text,
	img blob(4200000),
	added_on date,
	modified_on date,
	price int unsigned,
	
	measure_unit_id int unsigned,
	index(measure_unit_id),
	foreign key (measure_unit_id) references measure_unit(id)
		on delete restrict
		on update restrict,

	category_id int unsigned,
	index(category_id),
	foreign key (category_id) references category(id)
		on delete restrict
		on update restrict,

	is_deleted bool default false
);

create table balance(
	product_id int unsigned,
	unique index(product_id),
	foreign key (product_id) references product(id)
		on delete restrict
		on update restrict,

	quantity int unsigned
);

create table operation(
	id int unsigned primary key auto_increment,

	user_id int unsigned,
	index(user_id),
	foreign key (user_id) references user(id)
		on delete restrict
		on update restrict,

	product_id int unsigned,
	index(product_id),
	foreign	key (product_id) references balance(product_id)
		on delete cascade
		on update cascade,

	quantity int
);

create table order_status (
	id int unsigned primary key auto_increment,
	name varchar(30)
);

create table buy_order(
	id int unsigned primary key auto_increment,

	buyer_id int unsigned,
	index(buyer_id),
	foreign key (buyer_id) references organization(id)
		on delete restrict
		on update restrict,

	seller_id int unsigned,
	index(seller_id),
	foreign key (seller_id) references organization(id)
		on delete restrict
		on update restrict,

	sent_on date,
	deliver_date date,

	address_id int unsigned,
	index(address_id),
	foreign key (address_id) references address(id)
		on delete restrict
		on update restrict,

	status_id int unsigned,
	index(status_id),
	foreign key (status_id) references order_status(id)
		on delete restrict
		on update restrict,

	order_sum int unsigned
);

create table order_content(
	id int unsigned primary key auto_increment,

	order_id int unsigned,
	index(order_id),
	foreign key (order_id) references buy_order(id)
		on delete cascade
		on update cascade,

	product_id int unsigned,
	index(product_id),
	foreign key (product_id) references product(id)
		on delete set null
		on update set null,

	quantity int unsigned,
	product_name varchar(50),
	product_price int unsigned,
	product_measure_unit varchar(30),
	pos_sum int unsigned,

	unique index(order_id, product_id)
);