USE [FabricFinder]
GO


set identity_insert [UserProfile] on
INSERT INTO [UserProfile]
([Id], FirebaseUserId, Email) VALUES (1, 'oDyfQGHL0TdnPbrZtEsAJmpS6or1', 'user1@email.com');
INSERT INTO [UserProfile]
([Id], FirebaseUserId, Email) VALUES (2, '2RtcfuG0grZOcxx9dY1UD0shrp73', 'user2@email.com');
set identity_insert [UserProfile] off


set identity_insert [FabricType] on
INSERT INTO [FabricType]
([Id], Type) VALUES (1, 'Woven');
INSERT INTO [FabricType]
([Id], Type) VALUES (2, 'Knit');
set identity_insert [FabricType] off


set identity_insert [Fabric] on
INSERT INTO [Fabric]
  ([Id], [Name], Color, Yardage, ImageUrl, UserId, FabricTypeId) VALUES
(1, 'Double Brushed Poly', 'Yellow', 3, 'https://cdn.shopify.com/s/files/1/2444/8261/products/20190930-122658_394x.jpg?v=1658189799', 1, 2);
INSERT INTO [Fabric]
  ([Id], [Name], Color, Yardage, ImageUrl, UserId, FabricTypeId) VALUES
(2, 'QUilting cotton', 'Purple', 1, 'https://cdn11.bigcommerce.com/s-z9t2ne/images/stencil/1280x1280/products/43861/408250/bulk-stickers-phx-1128__39076.1651594223.jpg?c=2?imbypass=on', 1, 1);
INSERT INTO [Fabric]
  ([Id], [Name], Color, Yardage, ImageUrl, UserId, FabricTypeId) VALUES
(3, 'Raw Silk', 'Teal', 1.5, 'https://i.etsystatic.com/5977438/r/il/d02c53/2889321001/il_570xN.2889321001_n72w.jpg', 1, 1);
INSERT INTO [Fabric]
  ([Id], [Name], Color, Yardage, ImageUrl, UserId, FabricTypeId) VALUES
(4, 'Summer Ponte', 'Blue', 2, 'https://www.joann.com/dw/image/v2/AAMM_PRD/on/demandware.static/-/Sites-joann-product-catalog/default/dwca6cb580/images/hi-res/master/zprd_15781016a.jpg?sw=556&sh=680&sm=fit', 1, 2);
INSERT INTO [Fabric]
  ([Id], [Name], Color, Yardage, ImageUrl, UserId, FabricTypeId) VALUES
(5, 'Duck Canvas', 'Red', 5, 'https://imgprd19.hobbylobby.com/a/29/98/a299876d03c41411975d20dd0df1304e8c88ff30/700Wx700H-627216-0918.jpg', 1, 1);
INSERT INTO [Fabric]
  ([Id], [Name], Color, Yardage, ImageUrl, UserId, FabricTypeId) VALUES
(6, 'ITY Interlock', 'Mocha Light', 3, 'https://m.media-amazon.com/images/I/71fknRMYjwL._AC_UL320_.jpg', 2, 2);
INSERT INTO [Fabric]
  ([Id], [Name], Color, Yardage, ImageUrl, UserId, FabricTypeId) VALUES
(7, 'Stretch Lace', 'Black', 2.0, 'https://m.media-amazon.com/images/I/61kUQe4lnRL._AC_.jpg', 2, 2);
INSERT INTO [Fabric]
  ([Id], [Name], Color, Yardage, ImageUrl, UserId, FabricTypeId) VALUES
(8, 'Calico Cotton', 'Yellow', .5, 'https://imgprd19.hobbylobby.com/a/1a/b2/a1ab2f44b71419738ec99c81da091981c08f3da8/350Wx350H-111005-0319.jpg', 2, 1);
INSERT INTO [Fabric]
  ([Id], [Name], Color, Yardage, ImageUrl, UserId, FabricTypeId) VALUES
(9, 'Corduroy', 'Green', 2, 'https://secure.img1-cg.wfcdn.com/im/55689200/compr-r85/2775/27750872/brookfield-corduroy-fabric.jpg', 2, 1);
INSERT INTO [Fabric]
  ([Id], [Name], Color, Yardage, ImageUrl, UserId, FabricTypeId) VALUES
(10, 'Athletic Poly Spandex', 'Grey', 2, 'https://cdn.shopify.com/s/files/1/0019/8541/3229/products/DHARMAHeatheredLightGreyTFF_620x.jpg?v=1596916704', 2, 2);
set identity_insert [Fabric] off




set identity_insert [Pattern] on
INSERT INTO [Pattern] 
([Id],[UserId], [Name], ImageUrl) VALUES (1, 1, 'Red Carpet Dress', 'https://www.patternsforpirates.com/wp-content/uploads/2022/11/Slide2-e1669143627788.jpg');
INSERT INTO [Pattern] 
([Id], [UserId], [Name], ImageUrl) VALUES (2, 1, 'Lumberjack', 'https://www.patternsforpirates.com/wp-content/uploads/2021/11/Slide3-1-e1636064101400-300x300.jpg');
INSERT INTO [Pattern] 
([Id], [UserId],[Name], ImageUrl) VALUES (3, 1, 'Brunch Blouse and Dress', 'https://www.patternsforpirates.com/wp-content/uploads/2017/09/Slide1-1-e1505324797467-300x300.jpg');
INSERT INTO [Pattern] 
([Id], [UserId], [Name], ImageUrl) VALUES (4, 2,'Cozy Pants', 'https://www.patternsforpirates.com/wp-content/uploads/2020/11/Slide3-1-e1606173098428-300x300.jpg');
INSERT INTO [Pattern] 
([Id], [UserId], [Name], ImageUrl) VALUES (5, 2, 'Vintage Jumper', 'https://www.patternsforpirates.com/wp-content/uploads/2020/10/Slide4-1-e1601586516611-300x300.jpg');
INSERT INTO [Pattern] 
([Id], [UserId], [Name], ImageUrl) VALUES (6, 2, 'Sugar Maple Skirt', 'https://www.patternsforpirates.com/wp-content/uploads/2022/04/Sugar-Maple-Adult-Thumbnail-300x300.jpg');
set identity_insert [Pattern] off



set identity_insert [PatternFabric] on
INSERT INTO [PatternFabric]
([Id], UserId, PatternId, FabricId) VALUES (1, 1, 1, 6);
INSERT INTO [PatternFabric]
([Id],UserId,PatternId, FabricId) VALUES (2, 1, 6, 1);
INSERT INTO [PatternFabric]
([Id],UserId,PatternId, FabricId) VALUES (3, 1, 2, 5);
INSERT INTO [PatternFabric]
([Id],UserId,PatternId, FabricId) VALUES (4, 2, 5, 9);
INSERT INTO [PatternFabric]
([Id],UserId,PatternId, FabricId) VALUES (5, 2, 4, 1);
INSERT INTO [PatternFabric]
([Id],UserId,PatternId, FabricId) VALUES (6, 2, 3, 3);
set identity_insert [PatternFabric] off



