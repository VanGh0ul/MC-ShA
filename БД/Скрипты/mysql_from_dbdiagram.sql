CREATE TABLE `user_status` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(20)
);

CREATE TABLE `user` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(50),
  `company_name` varchar(50),
  `email` varchar(20),
  `phone` varchar(12),
  `avatar` blob(4200000),
  `password` varchar(16),
  `status` int,
  `reg_date` date
);

CREATE TABLE `product_status` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(30)
);

CREATE TABLE `measure_unit_type` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(30)
);

CREATE TABLE `product` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `seller_id` int,
  `name` varchar(50),
  `about` text,
  `status` int,
  `img` blob(4200000),
  `added_on` date,
  `modified_on` date,
  `price` int,
  `measure_unit` int
);

CREATE TABLE `category` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(50)
);

CREATE TABLE `category_content` (
  `category_id` int,
  `product_id` int
);

CREATE TABLE `order_status` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(50)
);

CREATE TABLE `buy_order` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `buyer_id` int,
  `seller_id` int,
  `sent_on` date,
  `deliver_date` date,
  `deliver_address` varchar(50),
  `status` int
);

CREATE TABLE `order_content` (
  `order_id` int,
  `product_id` int,
  `quantity` int,
  `product_name` varchar(50),
  `product_price` int,
  `product_measure_unit` varchar(30)
);

ALTER TABLE `user` ADD FOREIGN KEY (`status`) REFERENCES `user_status` (`id`);

ALTER TABLE `product` ADD FOREIGN KEY (`seller_id`) REFERENCES `user` (`id`);

ALTER TABLE `product` ADD FOREIGN KEY (`status`) REFERENCES `product_status` (`id`);

ALTER TABLE `product` ADD FOREIGN KEY (`measure_unit`) REFERENCES `measure_unit_type` (`id`);

ALTER TABLE `category_content` ADD FOREIGN KEY (`category_id`) REFERENCES `category` (`id`);

ALTER TABLE `category_content` ADD FOREIGN KEY (`product_id`) REFERENCES `product` (`id`);

ALTER TABLE `buy_order` ADD FOREIGN KEY (`buyer_id`) REFERENCES `user` (`id`);

ALTER TABLE `buy_order` ADD FOREIGN KEY (`seller_id`) REFERENCES `user` (`id`);

ALTER TABLE `buy_order` ADD FOREIGN KEY (`status`) REFERENCES `order_status` (`id`);

ALTER TABLE `order_content` ADD FOREIGN KEY (`order_id`) REFERENCES `buy_order` (`id`);

ALTER TABLE `order_content` ADD FOREIGN KEY (`product_id`) REFERENCES `product` (`id`);

CREATE INDEX `user_index_0` ON `user` (`name`);

CREATE INDEX `user_index_1` ON `user` (`company_name`);

CREATE INDEX `product_index_2` ON `product` (`name`);
