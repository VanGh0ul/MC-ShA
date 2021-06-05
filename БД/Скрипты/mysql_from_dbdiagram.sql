CREATE TABLE `users` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(50),
  `company_name` varchar(50),
  `email` varchar(20),
  `phone` varchar(10),
  `avatar` blob(4200000),
  `password` varchar(16),
  `status` ENUM ('admin', 'usual'),
  `reg_date` date
);

CREATE TABLE `products` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `seller_id` int,
  `name` varchar(50),
  `about` text,
  `status` ENUM ('in_stock', 'not_in_stock'),
  `avatar` blob(4200000),
  `added_on` date,
  `price` int,
  `measure_unit` ENUM ('g', 'kg', 't', 'ml', 'l', 'units')
);

CREATE TABLE `categories` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(50)
);

CREATE TABLE `category_content` (
  `category_id` int,
  `product_id` int
);

CREATE TABLE `orders` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `buyer_id` int,
  `seller_id` int,
  `sent_on` date,
  `deliver_date` date,
  `deliver_address` varchar(50),
  `status` ENUM ('editing', 'waiting', 'accepted', 'declined')
);

CREATE TABLE `order_content` (
  `order_id` int,
  `product_id` int,
  `quantity` int
);

ALTER TABLE `products` ADD FOREIGN KEY (`seller_id`) REFERENCES `users` (`id`);

ALTER TABLE `category_content` ADD FOREIGN KEY (`category_id`) REFERENCES `categories` (`id`);

ALTER TABLE `category_content` ADD FOREIGN KEY (`product_id`) REFERENCES `products` (`id`);

ALTER TABLE `orders` ADD FOREIGN KEY (`buyer_id`) REFERENCES `users` (`id`);

ALTER TABLE `orders` ADD FOREIGN KEY (`seller_id`) REFERENCES `users` (`id`);

ALTER TABLE `order_content` ADD FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`);

ALTER TABLE `order_content` ADD FOREIGN KEY (`product_id`) REFERENCES `products` (`id`);

CREATE INDEX `users_index_0` ON `users` (`name`);

CREATE INDEX `users_index_1` ON `users` (`company_name`);

CREATE INDEX `products_index_2` ON `products` (`name`);
