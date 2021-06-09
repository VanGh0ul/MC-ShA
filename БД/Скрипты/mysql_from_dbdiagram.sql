CREATE TABLE `user_role` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(20)
);

CREATE TABLE `user` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `organization_id` int COMMENT 'on delete restrict, on update restrict',
  `name` varchar(50),
  `email` varchar(20),
  `password` varchar(18),
  `role_id` int COMMENT 'on delete restrict, on update restrict',
  `reg_date` date
);

CREATE TABLE `organization` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(50),
  `about` text,
  `email` varchar(20),
  `phone` varchar(12),
  `avatar` blob(4200000),
  `reg_date` date
);

CREATE TABLE `measure_unit` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(30)
);

CREATE TABLE `balance` (
  `product_id` int,
  `quantity` int
);

CREATE TABLE `operations` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `user_id` int COMMENT 'on delete set null, on update set null',
  `product_id` int COMMENT 'on delete cascade, on update cascade',
  `quantity` int
);

CREATE TABLE `product` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `seller_id` int COMMENT 'on delete restrict, on update restrict',
  `name` varchar(50),
  `about` text,
  `img` blob(4200000),
  `added_on` date,
  `modified_on` date,
  `price` int,
  `measure_unit_id` int COMMENT 'on delete restrict, on update restrict'
);

CREATE TABLE `category` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(50)
);

CREATE TABLE `category_content` (
  `category_id` int COMMENT 'on delete restrict, on update restrict',
  `product_id` int COMMENT 'on delete cascade, on update cascade'
);

CREATE TABLE `order_status` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(50)
);

CREATE TABLE `buy_order` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `buyer_id` int COMMENT 'on delete restrict, on update restrict',
  `seller_id` int COMMENT 'on delete restrict, on update restrict',
  `sent_on` date,
  `deliver_date` date,
  `deliver_address` varchar(50),
  `status_id` int COMMENT 'on delete restrict, on update restrict',
  `order_sum` int
);

CREATE TABLE `order_content` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `order_id` int COMMENT 'on delete cascade, on update cascade',
  `product_id` int COMMENT 'on delete set null, on update set null',
  `quantity` int,
  `product_name` varchar(50),
  `product_price` int,
  `product_measure_unit` varchar(30),
  `pos_sum` int
);

ALTER TABLE `user` ADD FOREIGN KEY (`organization_id`) REFERENCES `organization` (`id`);

ALTER TABLE `user` ADD FOREIGN KEY (`role_id`) REFERENCES `user_role` (`id`);

ALTER TABLE `balance` ADD FOREIGN KEY (`product_id`) REFERENCES `product` (`id`);

ALTER TABLE `operations` ADD FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

ALTER TABLE `operations` ADD FOREIGN KEY (`product_id`) REFERENCES `balance` (`product_id`);

ALTER TABLE `product` ADD FOREIGN KEY (`seller_id`) REFERENCES `organization` (`id`);

ALTER TABLE `product` ADD FOREIGN KEY (`measure_unit_id`) REFERENCES `measure_unit` (`id`);

ALTER TABLE `category_content` ADD FOREIGN KEY (`category_id`) REFERENCES `category` (`id`);

ALTER TABLE `category_content` ADD FOREIGN KEY (`product_id`) REFERENCES `product` (`id`);

ALTER TABLE `buy_order` ADD FOREIGN KEY (`buyer_id`) REFERENCES `organization` (`id`);

ALTER TABLE `buy_order` ADD FOREIGN KEY (`seller_id`) REFERENCES `organization` (`id`);

ALTER TABLE `buy_order` ADD FOREIGN KEY (`status_id`) REFERENCES `order_status` (`id`);

ALTER TABLE `order_content` ADD FOREIGN KEY (`order_id`) REFERENCES `buy_order` (`id`);

ALTER TABLE `order_content` ADD FOREIGN KEY (`product_id`) REFERENCES `product` (`id`);

CREATE UNIQUE INDEX `user_index_0` ON `user` (`id`, `organization_id`);

CREATE INDEX `organization_index_1` ON `organization` (`name`);

CREATE UNIQUE INDEX `balance_index_2` ON `balance` (`product_id`);

CREATE INDEX `product_index_3` ON `product` (`name`);

CREATE UNIQUE INDEX `category_content_index_4` ON `category_content` (`category_id`, `product_id`);

CREATE UNIQUE INDEX `order_content_index_5` ON `order_content` (`order_id`, `product_id`);
