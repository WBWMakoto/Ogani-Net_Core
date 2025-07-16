--
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DoAnNhom')
BEGIN
    CREATE DATABASE DoAnNhom;
END
GO

--
USE DoAnNhom;
GO

-- Create ASP.NET Core Identity tables first
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] NVARCHAR(450) NOT NULL,
    [Name] NVARCHAR(256) NULL,
    [NormalizedName] NVARCHAR(256) NULL,
    [ConcurrencyStamp] NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [dbo].[AspNetUsers] (
    [Id] NVARCHAR(450) NOT NULL,
    [UserName] NVARCHAR(256) NULL,
    [NormalizedUserName] NVARCHAR(256) NULL,
    [Email] NVARCHAR(256) NULL,
    [NormalizedEmail] NVARCHAR(256) NULL,
    [EmailConfirmed] BIT NOT NULL,
    [PasswordHash] NVARCHAR(MAX) NULL,
    [SecurityStamp] NVARCHAR(MAX) NULL,
    [ConcurrencyStamp] NVARCHAR(MAX) NULL,
    [PhoneNumber] NVARCHAR(MAX) NULL,
    [PhoneNumberConfirmed] BIT NOT NULL,
    [TwoFactorEnabled] BIT NOT NULL,
    [LockoutEnd] DATETIMEOFFSET NULL,
    [LockoutEnabled] BIT NOT NULL,
    [AccessFailedCount] INT NOT NULL,
    -- Thêm hai cột tùy chỉnh thiếu
    [BirthDay] DATETIME2 NULL,
    [DisPlayName] NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO



CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR(450) NOT NULL,
    [RoleId] NVARCHAR(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [RoleId] NVARCHAR (450) NOT NULL,
    [ClaimType] NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [UserId] NVARCHAR (450) NOT NULL,
    [ClaimType] NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey] NVARCHAR (128) NOT NULL,
    [ProviderDisplayName] NVARCHAR (MAX) NULL,
    [UserId] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[AspNetUserTokens] (
    [UserId] NVARCHAR (450) NOT NULL,
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (128) NOT NULL,
    [Value] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

-- Create indexes for ASP.NET Core Identity tables
CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims] ([RoleId]);
GO
CREATE UNIQUE INDEX [RoleNameIndex] ON [dbo].[AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO
CREATE INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims] ([UserId]);
GO
CREATE INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins] ([UserId]);
GO
CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles] ([RoleId]);
GO
CREATE INDEX [EmailIndex] ON [dbo].[AspNetUsers] ([NormalizedEmail]);
GO
CREATE UNIQUE INDEX [UserNameIndex] ON [dbo].[AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO


-- Table: BlogPosts
CREATE TABLE [dbo].[BlogPosts] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Title] NVARCHAR(MAX) NULL,
    [Content] NVARCHAR(MAX) NULL,
    [ImageUrl] NVARCHAR(MAX) NULL,
    [CreatedDate] DATETIME2(7) NULL,
    [Author] NVARCHAR(MAX) NULL
);

-- Table: Comments
CREATE TABLE [dbo].[Comments] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Content] NVARCHAR(MAX) NULL,
    [UserId] NVARCHAR(MAX) NULL,
    [CreatedDate] DATETIME2(7) NULL,
    [BlogPostId] INT NULL,
    FOREIGN KEY ([BlogPostId]) REFERENCES [dbo].[BlogPosts]([Id])
);

-- Table: Categories
CREATE TABLE [dbo].[Categories] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(MAX) NULL,
    [Description] NVARCHAR(MAX) NULL
);

-- Table: Products
CREATE TABLE [dbo].[Products] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(MAX) NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Price] DECIMAL(18, 2) NULL,
    [iPrice] DECIMAL(18, 2) NULL,
    [ImageUrl] NVARCHAR(MAX) NULL,
    [CategoryId] INT NULL,
    [Discount] DECIMAL(18, 2) NULL,
    [Rating] FLOAT NULL,
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories]([Id])
);

CREATE TABLE [dbo].[Reviews] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ProductId] INT NOT NULL,
    [Rating] INT NOT NULL,
    [Comment] NVARCHAR(MAX) NULL,
    [UserId] NVARCHAR(450) NULL,

    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products]([Id]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers]([Id])
);
GO

-- Table: Orders
CREATE TABLE [dbo].[Orders] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserId] NVARCHAR(MAX) NULL,
    [OrderDate] DATETIME2(7) NULL,
    [TotalAmount] DECIMAL(18, 2) NULL,
    [Status] NVARCHAR(MAX) NULL,
    [FirstName] NVARCHAR(MAX) NULL,
    [LastName] NVARCHAR(MAX) NULL,
    [Country] NVARCHAR(MAX) NULL,
    [Address] NVARCHAR(MAX) NULL,
    [Address2] NVARCHAR(MAX) NULL,
    [City] NVARCHAR(MAX) NULL,
    [Phone] NVARCHAR(MAX) NULL,
    [Email] NVARCHAR(MAX) NULL,
    [OrderNotes] NVARCHAR(MAX) NULL,
    [PaymentMethod] NVARCHAR(MAX) NULL
);

-- Table: OrderDetails
CREATE TABLE [dbo].[OrderDetails] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [OrderId] INT NULL,
    [ProductId] INT NULL,
    [Quantity] INT NULL,
    [UnitPrice] DECIMAL(18, 2) NULL,
    [IsComment] BIT NULL,
    FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders]([Id]),
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products]([Id])
);

-- Table: ProductImages
CREATE TABLE [dbo].[ProductImages] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ImageUrl] NVARCHAR(MAX) NULL,
    [ProductId] INT NULL,
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products]([Id])
);


--
SET IDENTITY_INSERT [dbo].[BlogPosts] ON;

INSERT [dbo].[BlogPosts] ([Id], [Title], [Content], [ImageUrl], [CreatedDate], [Author]) VALUES (1, N'Cửa sổ góc tạo nên một không gian trong một nơi, là điểm nghỉ ngơi trong không gian rộng lớn.', N'Nhưng hãng hàng không đã chọn giá. Tòa nhà và sân quan trọng hơn yếu tố phương tiện nhưng nó cũng quan trọng. Curabitur không phải là thời điểm tốt nhất cho những người chơi đã đọc sách. Mauris tâng bốc giới thượng lưu, eget tincidunt nibh pulvinar a. Vivamus magna justo, eget consectetur sed, convallis và Tellus. Nhưng hãng hàng không đã chọn giá. Cho đến sự quan tâm của nhân viên. Curabitur không phải là thời điểm tốt nhất cho những người chơi đã đọc sách. Anh ấy cần một nụ cười thật tươi. Cho đến lúc đó, tôi cần phải làm bài tập về nhà. Curabitur không phải là thời điểm tốt nhất cho những người chơi đã đọc sách. Cho đến sự quan tâm của nhân viên. Không có thứ gọi là feugiat nam miễn phí. Đó là một kho lưu trữ, một lớp tài chính, đồng thời là một hãng hàng không.', N'https://traicayhoabien.com/wp-content/uploads/2020/12/Kiwi-tron-yen-mach-sua-chua.jpg', CAST(N'2025-04-04T15:28:01.7734489' AS DateTime2), N'admin@admin.com');
INSERT [dbo].[BlogPosts] ([Id], [Title], [Content], [ImageUrl], [CreatedDate], [Author]) VALUES (2, N'Mẹo lựa mận An Phước ngon và vô vàn cách biến tấu', N'Mận An Phước được nhiều người yêu thích với vị ngọt, giòn, mọng nước. Để mua được những trái mận ngon và biến tấu như thế nào, bạn hãy bỏ túi ngay những mẹo dưới đây nhé.
Lựa mận An Phước ngon dễ dàng như sau
Mận An Phước thường hay bị sâu. Mẹo kiểm tra mận có bị sâu hay không, bạn hãy bóp mạnh phần đầu nhọn trái, nếu phần bóp bị mục bể ra, bạn sẽ nhìn thấy con sâu,bạn hãy test thử vài trái trước khi mua nha.
Mẹo tiếp theo là bạn hãy quan sát phần đuôi của quả mận nếu nở nhiều thì chứng tỏ trái già, mận ngon còn phần đuôi co lại thì rất có thể trái còn non.

Không nên lựa cả chùm mà mà hãy chịu khó lựa từng quả.

Cầm mận lên và quan sát, mận cần rắn chắc, đỏ nhạt thêm chút trắng. Nếu đỏ quá đậm thì có thể mận bị phun thuốc kỹ.

Nên chọn những quả có vỏ mỏng, bóng và không dập nát.

Gợi ý cách ăn mận đúng cách

– Gỏi mận với tôm thịt

Chuẩn bị:

4 quả mận An Phước

Tôm thẻ

Thịt ba chỉ

Cà rốt, rau thơm và gia vị
Cách làm:

Tôm luộc, bỏ vỏ. Thịt ba luộc và cắt sợi mỏng. Mận cắt làm đôi, bỏ cuống, cắt lát mỏng và ngâm với nước chanh pha loãng để mận không bị thâm. Pha nước mắm theo tỷ lệ: 1 nước mắm: 1 đường: 1 cốt chanh, thêm ớt, tỏi băm nhỏ vào.  Cho thịt ba chỉ, tôm, mận, nước mắm vào cùng và trộn đều với nhau. Sau đó, thêm rau thơm, hành phi vào để tăng hương vị.

– Cocktail trái cây

Nguyên liệu:

Sơ ri, táo, mận, thơm.

 Đường phèn, nước lọc.', N'https://traicayhoabien.com/wp-content/uploads/2021/07/Salad-cam-quyt-kiwi.jpg', CAST(N'2025-04-06T08:25:31.2279356' AS DateTime2), N'admin@admin.com');
INSERT [dbo].[BlogPosts] ([Id], [Title], [Content], [ImageUrl], [CreatedDate], [Author]) VALUES (3, N'2 Món ngon từ Kiwi', N'1. Món bánh pudding kiwi hạt chia
Món bánh Pudding Kiwi hạt chia thanh mát và lôi cuốn vị giác này sẽ rất phù hợp để bạn khởi đầu cho một ngày mới đầy năng lượng, hoặc là món ăn vặt khá thú vị đấy.

Nguyên liệu chuẩn bị cho món bánh gồm 1 chén hạnh nhân, yến mạch, sữa dừa, 2 muỗng hạt chia, 2 trái kiwi chín, 2 muỗng canh siro agave hoặc mật ong.

Trước tiên hãy trộn hạt chia Organic với sữa trong bát sau đó để vào tủ lạnh qua một đêm. Buổi sáng hôm sau, bạn cắt kiwi thành từng lát mỏng kết hợp cùng với xoài, sau đó đặt lên trên bát hạt chia và bắt đầu thưởng thức thôi.
2. Bánh kiwi với kem dừa
Để làm món bánh này cần 100g bơ đã được làm tan chảy, 1 cốc Chelsea White Sugar, 4 quả trứng ,1/2 cốc bột, 2 cốc sữa, 2 muỗng cà phê tinh chất dừa, 1 chén dừa nạo sấy, 3 – 4 quả kiwi vàng

Trước tiên hãy trộn tất cả các nguyên liệu trong một dụng cụ chuyên dùng để nướng bánh. Cho vào lò nướng dễ điều chỉnh nhiệt độ khoảng 180 độ C trong khoảng 1h. Sau đó, lấy bánh ra để nguội và làm lạnh.

Kiwi được cắt thành từng miếng nhỏ và ăn kèm với bánh. Bạn có thể cho thêm chút nước cốt dừa để tăng hương vị của món ăn. Với cách chế biến này, bạn đã có một món ngon với kiwi vừa đảm bảo dinh dưỡng, vừa cung cấp năng lượng một cách tuyệt vời cho cơ thể.', N'https://traicayhoabien.com/wp-content/uploads/2020/12/Sinh-to-kiwi-rau-bina.jpg', CAST(N'2025-04-06T08:28:58.5105188' AS DateTime2), N'admin@admin.com');

SET IDENTITY_INSERT [dbo].[BlogPosts] OFF;

--
SET IDENTITY_INSERT [dbo].[Categories] ON;

INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (1, N'Trái cây', N'trái cây tươi nhập khẩu');
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (2, N'trái cây sấy khô', N'khô');
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (3, N' Rau', N'rau');
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (4, N'Nước ép trái cây', N'nước');
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (5, N'Rau gia vị', N'rau');
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (6, N'Rau hữu cơ', N'rau');
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (7, N'Rau củ hữu cơ', N'rau'); -- Added based on Product 9, 25, 26, 27 CategoryId

SET IDENTITY_INSERT [dbo].[Categories] OFF;
--
SET IDENTITY_INSERT [dbo].[Products] ON;

INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (1, N'Mận đỏ ruột vàng Red Candy Úc - 500G', N'Đạt tiêu chuẩn chất lượng nhập khẩu
Hình dáng: Quả mận có hình tròn hoặc hơi bầu dục, vỏ màu đỏ bóng, có lớp phấn trắng mỏng.
Hương vị: Thịt quả màu vàng, giòn, ngọt thanh, xen lẫn chút chua nhẹ, mọng nước, ít xơ. Hạt mận nhỏ, dễ tách.
Có một lớp phấn trắng tự nhiên trên vỏ quả.', CAST(81965.00 AS Decimal(18, 2)), CAST(84500.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/man_do_ruot_vang_red_candy_uc_13800a1dfe9e431e8579e42c8b8dc0a7_1024x1024.jpg', 1, CAST(3.00 AS Decimal(18, 2)), 4);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (2, N'Dưa lê hoàng kim Hàn Quốc', N'Đạt tiêu chuẩn chất lượng nhập khẩu. Có phần thịt giòn ngọt, mọng nước và giải nhiệt tươi mát. 

Tuy vậy, dưa lưới Hoàng Kim sẽ có độ ngọt hơn các giống dưa khác và hương vị thanh hơn.', CAST(231570.00 AS Decimal(18, 2)), CAST(249000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/dua_le_hoang_kim_han_quoc___2_trai___hop___3370781368d645aeb43d865764620c43_1024x1024.jpg', 1, CAST(7.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (3, N'Quýt baby nội địa Trung - 1Kg', N'https://product.hstatic.net/1000141988/product/quyt_baby_noi_dia_trung_7bc084330dc34db38af2d33d81bef51c_1024x1024.jpg', CAST(56640.00 AS Decimal(18, 2)), CAST(59000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/quyt_baby_noi_dia_trung_7bc084330dc34db38af2d33d81bef51c_1024x1024.jpg', 1, CAST(4.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (4, N'Táo Posy New Zealand', N'Nguồn gốc:
Táo Posy có nguồn gốc từ New Zealand, một quốc gia nổi tiếng với chất lượng trái cây cao.
Hương vị:
Táo Posy có hương vị ngọt ngào, thanh mát, với chút vị chua nhẹ.
Có hương vị thơm ngon, thanh mát, như hương vị dưa hấu kết hợp cùng đào.
Hình thức:
Táo có màu sắc đỏ hồng tươi đẹp mắt, vỏ mỏng, thịt dày, giòn và mọng nước.
Vỏ táo trơn láng, mịn màng, toát lên vẻ đẹp thu hút.
Đóng gói:
Được đóng gói trong ống nhựa tiện lợi, dễ dàng mang theo và bảo quản.
Mỗi ống chứa 4 trái táo.', CAST(113050.00 AS Decimal(18, 2)), CAST(119000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/tao_posy_new_zealand___4_trai___ong___07aa1b780c8d43be921f87f11a4970c7_1024x1024.jpg', 1, CAST(5.00 AS Decimal(18, 2)), 5);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (5, N'Ngò om Vietgap Châu Khoa - 100G', N'Ngò om, một loại rau thơm gia vị quen thuộc trong ẩm thực Việt Nam, không chỉ mang đến hương vị thơm nồng đặc trưng mà còn là nguồn cung cấp dồi dào vitamin và khoáng chất. Với sản phẩm Ngò om Vietgap Châu Khoa, bạn hoàn toàn yên tâm về chất lượng và nguồn gốc của sản phẩm.', CAST(4950.00 AS Decimal(18, 2)), CAST(4950.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/rau_om_0d9ff4711e5c4a4aa43c0a7bb0875fd4_grande.jpg', 6, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (6, N'Ngò rí Vietgap Trường Phát 30 g', N'Trồng theo tiêu chuẩn VietGAP: Đảm bảo sản phẩm sạch, không sử dụng hóa chất độc hại, an toàn cho sức khỏe.
Tươi ngon: Ngò rí luôn tươi xanh, lá dày, có mùi thơm đặc trưng.
Hương vị đậm đà: Mang đến hương vị thơm ngon, giúp món ăn thêm hấp dẫn.
Đóng gói tiện lợi: Gói 30g nhỏ gọn, dễ bảo quản và sử dụng.
Giàu dinh dưỡng: Ngò rí chứa nhiều vitamin, khoáng chất tốt cho sức khỏe.', CAST(8000.00 AS Decimal(18, 2)), CAST(8000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/ngo_ri_vietgap_truong_phat_30_g_c779227832da4c31bc75e74188422f1d_grande.png', 6, CAST(0.00 AS Decimal(18, 2)), 2);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (8, N'Mận đỏ An Phước', N'Mận Đỏ An Phước (KG) là một trái cây quen thuộc được nhiều người yêu thích bởi tác dụng thanh nhiệt. Mận được trồng tại An Phước với màu đỏ và bóng, trái to vừa và ngọt thanh, tỉ lệ gặp trái có vị chua rất ít (trừ trái còn xanh, chưa chín).', CAST(68000.00 AS Decimal(18, 2)), CAST(68000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/man_do_an_phuoc_1_6ac9d40029be4e33855c85bc6c56e4de_1024x1024.png', 1, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (9, N'Đậu que hữu cơ Bio Ngon 200 g', N'Đậu que hữu cơ Bio Ngon là một sản phẩm rau củ sạch, được trồng theo phương pháp hữu cơ, không sử dụng hóa chất, đảm bảo an toàn cho sức khỏe. Với màu xanh tươi mát, vị ngọt thanh và giòn mát, đậu que hữu cơ là một trong những loại rau được ưa chuộng trong các bữa ăn hàng ngày.', CAST(27000.00 AS Decimal(18, 2)), CAST(27000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/dau_que_huu_co_bio_ngon_200_g_c87e71947e6a43389f2ae376d0f36599_grande.jpg', 7, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (10, N'Hồng treo gió Ichida nội địa Nhật Bản ( 6 trái / vỉ )', N'Đặc điểm nổi bật của hồng treo gió Ichida:

Hương vị và chất lượng: Hồng Ichida có vị ngọt tự nhiên, ít hạt, và lớp phấn trắng mịn bao phủ bên ngoài.

Quy trình chế biến: Quá trình treo gió tự nhiên giúp quả hồng giữ được độ ngọt và hương thơm đặc trưng.

Giá trị dinh dưỡng: Hồng chứa nhiều vitamin và khoáng chất, tốt cho sức khỏe.', CAST(399000.00 AS Decimal(18, 2)), CAST(399000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/hong_treo_gio_ichida_noi_dia_nhat_ban__6_trai__vi____i0020767_3c9bd48eeb9a48d2a3a51d0197df6081_1024x1024.jpg', 3, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (11, N'Chuối sấy dẻo thanh long đỏ DannyGreen 270g', N'Nguyên liệu tự nhiên:
Chuối tươi và thanh long đỏ được chọn lọc kỹ càng.
Không chất bảo quản, không thêm đường.
Quy trình chế biến:
Chuối và thanh long đỏ được nghiền, cuộn và sấy ở nhiệt độ thấp, giữ lại tối đa dưỡng chất và hương vị tự nhiên.
Hương vị:
Vị ngọt tự nhiên của chuối và thanh long đỏ, dẻo thơm.', CAST(99000.00 AS Decimal(18, 2)), CAST(99000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/chuoi_say_deo_thanh_long_do_dannygreen_270g_36fae36db69749e08599f29cbe79aff7_grande.png', 3, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (12, N'Hạt hạnh nhân rang bơ Farmers Fine Foods 140 g', N'Là sản phẩm được làm từ 100% hạt hạnh nhân tự nhiên, chọn lọc kỹ lưỡng, rang sấy thủ công trên lửa nhỏ và tẩm ướp gia vị bơ đậm đà. Sản phẩm không chứa Trans Fat, không Cholesterol, không chất phụ gia, không chất bảo quản, giữ nguyên hương vị thơm ngon và dinh dưỡng của hạt hạnh nhân. Hạt Hạt hạnh nhân rang bơ Farmers Fine Foods 140 g là món ăn vặt bổ dưỡng, tiện lợi, thích hợp cho mọi lứa tuổi.', CAST(86000.00 AS Decimal(18, 2)), CAST(86000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/hat_hanh_nhan_rang_bo_farmers_fine_foods_140_g__i0018724__d1c7e5a4a0984111b737e8413c3d15e3_1024x1024.jpg', 3, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (13, N'Hạt mắc ca úc Farmers Fine Foods 180 g', N'- Là sản phẩm được làm từ những hạt Macca được tuyển chọn kỹ lưỡng, đảm bảo chất lượng thượng hạng. Hạt to, đều, có màu nâu vàng tự nhiên, vỏ mỏng, giòn, dễ tách và nhân Macca bùi béo, thơm ngon, giàu dinh dưỡng.

- Đặc điểm: Nguyên vỏ, to, đều, màu nâu vàng tự nhiên, vỏ mỏng, giòn, dễ tách, nhân bùi béo, thơm ngon, giàu dinh dưỡng', CAST(109000.00 AS Decimal(18, 2)), CAST(109000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/hat_mac_ca_uc_farmers_fine_foods_180_g__i0018730__2b0b8757f95c42edb006352401bf6b13_1024x1024.jpg', 3, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (14, N'Xoài sấy dẻo Farmers Fine Foods 100 g', N'Cung cấp năng lượng: Xoài sấy dẻo là nguồn cung cấp năng lượng nhanh chóng, giúp bạn tỉnh táo và tập trung hơn.
Tốt cho tiêu hóa: Chất xơ trong xoài giúp hỗ trợ hệ tiêu hóa, ngăn ngừa táo bón.
Cải thiện thị lực: Vitamin A có trong xoài tốt cho mắt, giúp bảo vệ thị lực.
Tăng cường hệ miễn dịch: Vitamin C giúp tăng cường hệ miễn dịch, bảo vệ cơ thể khỏi các bệnh nhiễm trùng.
Làm đẹp da: Các chất chống oxy hóa trong xoài giúp bảo vệ da khỏi tác hại của gốc tự do, ngăn ngừa lão hóa.', CAST(71000.00 AS Decimal(18, 2)), CAST(71000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/xoai_say_deo_farmers_fine_foods_100_g__i0018795__1bbc0fa280cb4eb08b1c234a72fdedf4_1024x1024.jpg', 3, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (15, N'Cải bó xôi Vietgap Châu Khoa 300g', N'Trồng trọt theo tiêu chuẩn VietGAP: Đảm bảo quy trình sản xuất sạch, an toàn, không sử dụng hóa chất độc hại.
Giàu dinh dưỡng: Cải bó xôi chứa nhiều vitamin A, C, K, sắt, canxi, chất xơ, tốt cho sức khỏe.
Hương vị thơm ngon: Cải bó xôi tươi ngon, mang đến hương vị đặc trưng, kích thích vị giác.
Đa dạng món ăn: Cải bó xôi có thể chế biến thành nhiều món ăn ngon như xào tỏi, nấu canh, làm salad...
Tiện lợi: Đóng gói sẵn, dễ bảo quản và chế biến.', CAST(38600.00 AS Decimal(18, 2)), CAST(38600.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/cai_bo_xoi_vietgap_6867fd2cfd144a3ba78add8347f7a088_grande.png', 4, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (16, N'Rau muống VietGAP', N'Công dụng tuyệt vời của rau muống:

Tăng cường hệ miễn dịch: Nhờ hàm lượng vitamin C cao.
Hỗ trợ tiêu hóa: Chất xơ giúp hệ tiêu hóa hoạt động ổn định.
Giảm cân: Rau muống có ít calo, giàu chất xơ, giúp tạo cảm giác no lâu, hỗ trợ giảm cân.
Làm đẹp da: Vitamin A, C giúp làn da khỏe mạnh, sáng mịn.
Các món ăn ngon từ rau muống:

Rau muống xào tỏi: Món ăn đơn giản, nhanh gọn, giàu dinh dưỡng.
Canh chua rau muống: Món ăn thanh mát, giải nhiệt cơ thể.
Gỏi rau muống tôm thịt: Món ăn khai vị hấp dẫn, giàu dinh dưỡng.
Rau muống luộc chấm mắm: Món ăn dân dã, đậm đà hương vị.', CAST(17000.00 AS Decimal(18, 2)), CAST(17000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/rau_muong_vietgap_-_300g_5e04027c6fea456fa440b7a4f517594e_grande.jpg', 4, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (17, N'Mồng tơi Vietgap Bio Ngon - 300G', N'Công dụng tuyệt vời của mồng tơi:

Tăng cường hệ miễn dịch: Nhờ hàm lượng vitamin C cao.
Hỗ trợ tiêu hóa: Chất xơ giúp hệ tiêu hóa hoạt động ổn định.
Giảm cân: Mồng tơi có ít calo, giàu chất xơ, giúp tạo cảm giác no lâu, hỗ trợ giảm cân.
Làm đẹp da: Vitamin A, C giúp làn da khỏe mạnh, sáng mịn.
Các món ăn ngon từ mồng tơi:

Canh mồng tơi thịt bằm: Món ăn dân dã, thanh mát, rất thích hợp cho ngày hè.
Mồng tơi xào tỏi: Món ăn đơn giản, nhanh gọn, giàu dinh dưỡng.
Lẩu mồng tơi: Món ăn ấm bụng, hợp khẩu vị của nhiều người.
Gỏi mồng tơi: Món ăn khai vị thanh mát, lạ miệng.', CAST(19500.00 AS Decimal(18, 2)), CAST(19500.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/mong_toi_vietgap_bio_ngon_-_300g__i0013791__176e59372657436089dc2bb96e673ef0_grande.png', 4, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (18, N'Rau má Vietgap Châu Khoa 300g', N'Công dụng tuyệt vời của rau má:

Giải nhiệt: Rau má có tính mát, giúp làm dịu cơ thể, giảm cảm giác nóng bức.
Thanh lọc cơ thể: Rau má giúp thanh lọc máu, loại bỏ độc tố.
Làm đẹp da: Rau má giúp làm dịu da, giảm mụn, ngăn ngừa lão hóa.
Cải thiện trí nhớ: Rau má có tác dụng tốt đối với hệ thần kinh, giúp cải thiện trí nhớ.
Hỗ trợ điều trị: Rau má được sử dụng để hỗ trợ điều trị một số bệnh như nóng trong, mẩn ngứa, rôm sảy.
Cách sử dụng rau má:

Xay nước uống: Rau má xay lấy nước là cách phổ biến nhất để giải nhiệt.
Nấu canh: Rau má có thể nấu canh với thịt, tôm, hoặc kết hợp với các loại rau khác.
Làm mặt nạ: Rau má xay nhuyễn có thể dùng để đắp mặt nạ làm đẹp da.', CAST(23700.00 AS Decimal(18, 2)), CAST(23700.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/rau_ma_vietgap_e678725083364995b67306cdeb51e85f_grande.jpg', 4, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (19, N'Star Kombucha - Ổi hồng', N'Trà lên men Star Kombucha vị ổi hồng (250ML)
Đóng gói: 6Lon/Lốc
Thay vì lựa chọn những loại thức uống không lành mạnh, chứa nhiều nguy cơ tiềm ẩn thì bạn nên tìm hiểu và thử ngay Kombucha - một loại thức uống lên men được làm từ quá trình lên men bao gồm trà (thường là dùng trà đen, trà xanh), đường và Scoby (một loại cộng sinh của vi khuẩn và nấm men), có vị chua và ngọt tự nhiên.

Vì thế mà kombucha dần trở thành một đồ uống thay thế lành mạnh và được sử dụng rộng rãi khắp các nước từ Mỹ đến Canada, Pháp, Đức,...Và ở Việt Nam cũng đang dần được biết đến nhiều hơn với dòng sản phẩm Star Kombucha, thương hiệu kombucha đầu tiên tại Việt Nam được sản xuất theo tiêu chuẩn và công thức Hoa Kỳ, đạt được chứng nhận chất lượng từ FDA Mỹ.

Trà lên men Star Kombucha vị ổi hồng (250ML) có vị chua và ngọt tự nhiên từ kombucha sau khi lên men kết hợp thêm hương thơm nồng ngọt ngào của ổi hồng càng làm cho món uống trở nên hấp dẫn hơn bao giờ hết. Thích hợp dùng sau bữa ăn hoặc khi bạn cảm thấy mệt mỏi, căng thẳng thì 1 lon star kombucha sẽ giúp bạn giải tỏa và thư giãn, nạp thêm năng lượng cho một ngày dài hoạt động và làm việc.', CAST(120000.00 AS Decimal(18, 2)), CAST(120000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/tra_len_men_star__kombucha_vi_oi_hong_250ml_8c2ff349cb8445c1a4fdaa2ea21b45c6_1024x1024.jpg', 5, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (20, N'Star Kombucha - Cam Đào', N'Trà lên men Star Kombucha vị cam đào (250ML)
Đóng gói: 6lon/Lốc
Thay vì lựa chọn những loại thức uống không lành mạnh, chứa nhiều nguy cơ tiềm ẩn thì bạn nên tìm hiểu và thử ngay Kombucha - một loại thức uống lên men được làm từ quá trình lên men bao gồm trà (thường là dùng trà đen, trà xanh), đường và Scoby (một loại cộng sinh của vi khuẩn và nấm men), có vị chua và ngọt tự nhiên.

Vì thế mà kombucha dần trở thành một đồ uống thay thế lành mạnh và được sử dụng rộng rãi khắp các nước từ Mỹ đến Canada, Pháp, Đức,...Và ở Việt Nam cũng đang dần được biết đến nhiều hơn với dòng sản phẩm Star Kombucha, thương hiệu kombucha đầu tiên tại Việt Nam được sản xuất theo tiêu chuẩn và công thức Hoa Kỳ, đạt được chứng nhận chất lượng từ FDA Mỹ.

Trà lên men Star Kombucha vị cam đào (250ML) có vị chua và ngọt tự nhiên từ kombucha sau khi lên men kết hợp thêm hương vị chua ngọt của cam đào càng làm tăng thêm sự sảng khoái và đậm đà cho món uống. Thích hợp dùng sau bữa ăn hoặc khi bạn cảm thấy mệt mỏi, căng thẳng thì 1 lon star kombucha sẽ giúp bạn giải tỏa và thư giãn, nạp thêm năng lượng cho một ngày dài hoạt động và làm việc.', CAST(37000.00 AS Decimal(18, 2)), CAST(37000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/tra_len_men_star__kombucha_vi_cam_dao_250ml_592f4a6ebbea49598d24a274abd03063_1024x1024.jpg', 5, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (21, N'Nước ép dừa và chanh Le Fruit 250 ml', N'
Thương hiệu	
Le Fruit (Pháp)

Thành phần	
98.5% dừa tươi, 1.5% chanh

Lượng đường	
Không đường

Hương vị	
Dừa, chanh', CAST(49000.00 AS Decimal(18, 2)), CAST(49000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/nuoc_ep_dua_va_chanh_le_fruit_250_ml__i0002294__f21d4beff44c4a6390d44d31d27defda_grande.png', 5, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (22, N'Nước mía và tắc Le Fruit 250 ml', N'Điểm đặc biệt:

Nước ép hỗn hợp
Tại trung tâm đồng bằng sông Cửu Long, chúng tôi chọn những loại trái cây tươi, ngon nhất của các nông trại gia đình địa phương. Nước Mía Tắc có vị ngọt đặc trưng từ mía, ngoài ra còn có một chút vị tắc nhẹ nhàng. Bạn sẽ cảm nhận vị ngọt ngào thuần khiết theo kiểu Việt Nam.

Thành Phần:

• 100% trái cây tươi bao gồm nước mía (97,5%), tắc (2,5%).
• Không có chất bảo quản và không đường. Không có chất phụ gia và biến đổi gen GMO.', CAST(49000.00 AS Decimal(18, 2)), CAST(49000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/nuoc_mia_va_tac_le_fruit_250_ml__i0002297__0fe67bc2f8b34cd79edc99b67d9b791f_grande.png', 5, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (23, N'Hành lá Vietgap - 100gr', N'Công dụng tuyệt vời của hành lá:

Tăng cường hệ miễn dịch: Nhờ vitamin C.
Tốt cho tiêu hóa: Chất xơ giúp hệ tiêu hóa hoạt động ổn định.
Giúp xương chắc khỏe: Nhờ hàm lượng canxi.
Chống oxy hóa: Giúp bảo vệ tế bào khỏi tổn thương.
Kháng khuẩn: Giúp tiêu diệt vi khuẩn gây hại.
Hướng dẫn sử dụng:

Hành lá có thể dùng để chế biến nhiều món ăn khác nhau. Bạn có thể tham khảo các công thức nấu ăn trên mạng để tạo ra những món ăn ngon và hấp dẫn.

Bảo quản:

Bảo quản hành lá trong ngăn mát tủ lạnh, để đảm bảo độ tươi ngon.', CAST(15000.00 AS Decimal(18, 2)), CAST(15000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/hanh_la_vietgap_-_100gr_a1c370349a564cd3b2d14e731070e000_grande.jpg', 6, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (24, N'Húng lủi Vietgap Bio Ngon 100 g', N'Công dụng tuyệt vời của húng lủi:

Tăng cường hệ miễn dịch: Nhờ vitamin C.
Tốt cho tiêu hóa: Chất xơ giúp hệ tiêu hóa hoạt động ổn định.
Giúp xương chắc khỏe: Nhờ hàm lượng canxi.
Chống oxy hóa: Giúp bảo vệ tế bào khỏi tổn thương.
Kháng khuẩn: Giúp tiêu diệt vi khuẩn gây hại.
Giảm căng thẳng: Hương thơm của húng lủi giúp thư giãn tinh thần.
Hướng dẫn sử dụng:

Húng lủi có thể dùng để chế biến nhiều món ăn khác nhau. Bạn có thể tham khảo các công thức nấu ăn trên mạng để tạo ra những món ăn ngon và hấp dẫn. Ngoài ra, húng lủi còn có thể dùng để pha trà hoặc làm gia vị cho các món đồ uống.

Bảo quản:

Bảo quản húng lủi trong ngăn mát tủ lạnh, để đảm bảo độ tươi ngon.', CAST(16000.00 AS Decimal(18, 2)), CAST(16000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/rau_hung_lui_vietgap_1_6d13a43a3c144a3f8db97c737396614c_1024x1024.png', 6, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (25, N'Cải bẹ xanh hữu cơ Gia Hưng 300 g', N'Cải bẹ xanh  hữu cơ Gia Hưng 300g - Giòn ngọt, bổ dưỡng, an toàn
Giới thiệu
Cải bẹ xanh, một loại rau xanh quen thuộc trong bữa ăn hàng ngày của người Việt, không chỉ mang đến hương vị giòn ngọt đặc trưng mà còn cung cấp nhiều dưỡng chất thiết yếu cho cơ thể. Đặc biệt, cải bẹ xanh organic Gia Hưng 300g được trồng theo phương pháp hữu cơ, đảm bảo an toàn và chất lượng, là lựa chọn hoàn hảo cho những người quan tâm đến sức khỏe.', CAST(35000.00 AS Decimal(18, 2)), CAST(35000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/cai_be_xanh_organic_gia_hung_300g__i0019581__baf6a42584954be6ab4eb9533d930e35_grande.jpg', 7, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (26, N'Rau dền hữu cơ Gia Hưng 300 g', N'Rau dền  hữu cơ Gia Hưng 300g - Nguồn dinh dưỡng xanh cho gia đình bạn
 Rau dền, một loại rau xanh quen thuộc trong bữa ăn hàng ngày của người Việt, không chỉ ngon miệng mà còn chứa hàm lượng dinh dưỡng cao. Đặc biệt, rau dền organic Gia Hưng 300g được trồng theo phương pháp hữu cơ, đảm bảo an toàn và chất lượng, là lựa chọn hoàn hảo cho những người quan tâm đến sức khỏe.
Lợi ích của rau dền đối với sức khỏe
Tăng cường hệ miễn dịch: Nhờ hàm lượng vitamin C cao, rau dền giúp tăng cường sức đề kháng, bảo vệ cơ thể khỏi các bệnh nhiễm trùng.
Tốt cho mắt: Vitamin A có trong rau dền giúp cải thiện thị lực, ngăn ngừa các bệnh về mắt.
Hỗ trợ tiêu hóa: Chất xơ trong rau dền giúp hệ tiêu hóa hoạt động ổn định, ngăn ngừa táo bón.
Ngăn ngừa ung thư: Các chất chống oxy hóa trong rau dền giúp bảo vệ tế bào, giảm nguy cơ mắc các bệnh ung thư.
Cách chế biến rau dền
Rau dền có thể chế biến thành nhiều món ăn ngon và bổ dưỡng như: canh rau dền nấu thịt bằm, rau dền xào tỏi, rau dền luộc chấm kho quẹt,...', CAST(35000.00 AS Decimal(18, 2)), CAST(35000.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/rau_den_organic_gia_hung_300_g_e20722c4321c47908d3dd4e988555d39_grande.jpg', 7, CAST(0.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [iPrice], [ImageUrl], [CategoryId], [Discount], [Rating]) VALUES (27, N'Bông cải xanh hữu cơ Food King - 250G ', N'Bông cải xanh hữu cơ Food King
Bông cải xanh hữu cơ Food King là một trong những loại rau củ được yêu thích bởi hàm lượng dinh dưỡng cao và hương vị thơm ngon. Được trồng theo phương pháp hữu cơ, không sử dụng hóa chất, thuốc trừ sâu, bông cải xanh Food King đảm bảo an toàn cho sức khỏe và mang đến những giá trị dinh dưỡng tuyệt vời.
Cách chọn mua và bảo quản:
Chọn bông cải: Chọn những cây bông cải xanh tươi, bông chắc, màu xanh đậm, không bị dập nát.
Bảo quản: Bảo quản trong ngăn mát tủ lạnh, bọc kín trong túi nilon.
Món ăn gợi ý:
Bông cải xanh luộc: Món ăn đơn giản, giữ nguyên được vị ngọt tự nhiên của bông cải.
Bông cải xanh xào tỏi: Món ăn thơm ngon, bổ dưỡng.
Bông cải xanh xào thịt bò: Kết hợp với thịt bò để tạo nên món ăn đầy đủ chất dinh dưỡng.
Bông cải xanh nấu súp: Món súp ấm áp, dễ tiêu hóa.', CAST(47550.00 AS Decimal(18, 2)), CAST(47550.00 AS Decimal(18, 2)), N'https://product.hstatic.net/1000141988/product/sup_lo_b8386bca487e442ea3f582622a95bea5_grande.jpg', 7, CAST(0.00 AS Decimal(18, 2)), 0);

SET IDENTITY_INSERT [dbo].[Products] OFF;
--
SET IDENTITY_INSERT [dbo].[Orders] ON;

INSERT [dbo].[Orders] ([Id], [UserId], [OrderDate], [TotalAmount], [Status], [FirstName], [LastName], [Country], [Address], [Address2], [City], [Phone], [Email], [OrderNotes], [PaymentMethod]) VALUES (2, N'69a590d4-d45f-421c-a468-d446ecc64b3a', CAST(N'2025-04-06T10:54:08.3843951' AS DateTime2), CAST(99640.00 AS Decimal(18, 2)), N'Delivered', N'Thương', N'Phan', N'Vietnam', N'thủ đức', NULL, N'HCM', N'0812370952', N'thuong06092008@gmail.com', N'xin rau tươi xíu nha', N'vnpay');

SET IDENTITY_INSERT [dbo].[Orders] OFF;
--
SET IDENTITY_INSERT [dbo].[OrderDetails] ON;

INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [IsComment]) VALUES (4, 2, 9, 1, CAST(27000.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [IsComment]) VALUES (5, 2, 6, 2, CAST(8000.00 AS Decimal(18, 2)), 0);
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [IsComment]) VALUES (6, 2, 3, 1, CAST(56640.00 AS Decimal(18, 2)), 0);

SET IDENTITY_INSERT [dbo].[OrderDetails] OFF;
--
SET IDENTITY_INSERT [dbo].[Comments] ON;

INSERT [dbo].[Comments] ([Id], [Content], [UserId], [CreatedDate], [BlogPostId]) VALUES (1, N'hay thế', N'admin@admin.com', CAST(N'2025-04-04T16:06:59.9713758' AS DateTime2), 1);
INSERT [dbo].[Comments] ([Id], [Content], [UserId], [CreatedDate], [BlogPostId]) VALUES (2, N'tuyệt vời :)', N'thuong06092008@gmail.com', CAST(N'2025-04-04T16:45:34.8752347' AS DateTime2), 1);

SET IDENTITY_INSERT [dbo].[Comments] OFF;
--
SET IDENTITY_INSERT [dbo].[ProductImages] ON;

INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (1, N'https://product.hstatic.net/1000141988/product/man_do_ruot_vang_red_candy_uc__2__4438c3d766764233b776177ecc2f4cd9_1024x1024.jpg', 1);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (2, N'https://product.hstatic.net/1000141988/product/man_do_ruot_vang_red_candy_uc.._50457928a00645ea8cfc66c9c71c5cf8_1024x1024.jpg', 1);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (3, N'https://product.hstatic.net/1000141988/product/dua_le_hoang_kim_han_quoc___2_trai___hop____2__b2e8343133a04551a327a1ffa4c5f7d1_1024x1024.jpg', 2);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (4, N'https://product.hstatic.net/1000141988/product/dua_le_hoang_kim_han_quoc___2_trai___hop____3__0089084df5d949e0974c9fbeb1d1aea9_1024x1024.jpg', 2);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (5, N'https://product.hstatic.net/1000141988/product/dua_le_hoang_kim_han_quoc___2_trai___hop____4__c6979768bd9d439d8b2de01f4f7bba11_1024x1024.jpg', 2);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (6, N'https://product.hstatic.net/1000141988/product/quyt_baby_noi_dia_trung__3__802b0f8014eb447ba3e6035903f3813c_1024x1024.jpg', 3);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (7, N'https://product.hstatic.net/1000141988/product/quyt_baby_noi_dia_trung__2__0da1208eca464489bad7d7556c48b04b_1024x1024.jpg', 3);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (8, N'https://product.hstatic.net/1000141988/product/tao_posy_new_zealand___4_trai___ong____2__821ca6cf87ad4c17bac44fcd535ab5dc_1024x1024.jpg', 4);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (9, N'https://product.hstatic.net/1000141988/product/tao_posy_new_zealand___4_trai___ong____4__e7430980b1f64da897986350d119c892_1024x1024.jpg', 4);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (10, N'https://product.hstatic.net/1000141988/product/tao_posy_new_zealand___4_trai___ong____3__8a93f86f0c8b489dbd803d90cfc3c28f_1024x1024.jpg', 4);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (11, N'https://product.hstatic.net/1000141988/product/man_do_an_phuoc_1.1_5ec0bd53a82a45c9873aef6ebc13907a_1024x1024.png', 8);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (12, N'https://product.hstatic.net/1000141988/product/upload_039e48c1831b4b62a883a92000789b8f_1024x1024.jpg', 8);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (13, N'https://product.hstatic.net/1000141988/product/hong_treo_gio_ichida_noi_dia_nhat_ban__6_trai__vi____i0020767__2__1f4373cf056b40c3b844d21e488d902b_1024x1024.jpg', 10);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (14, N'https://product.hstatic.net/1000141988/product/hong_treo_gio_ichida_noi_dia_nhat_ban__6_trai__vi____i0020767_270338243e4d4726b5812f8872e3726f_1024x1024.jpg', 10);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (15, N'https://product.hstatic.net/1000141988/product/hat_hanh_nhan_rang_bo_farmers_fine_foods_140_g__i0018724__d1c7e5a4a0984111b737e8413c3d15e3_1024x1024.jpg', 12);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (16, N'https://product.hstatic.net/1000141988/product/hat_hanh_nhan_rang_bo_farmers_fine_foods_140_g__i0018724___2__33981c1380a24efd8d61260888835a9e_1024x1024.jpg', 12);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (17, N'https://product.hstatic.net/1000141988/product/hat_mac_ca_uc_farmers_fine_foods_180_g__i0018730___3__22411740e1d247fa9fba140119742b2f_1024x1024.jpg', 13);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (18, N'https://product.hstatic.net/1000141988/product/hat_mac_ca_uc_farmers_fine_foods_180_g__i0018730__2b0b8757f95c42edb006352401bf6b13_1024x1024.jpg', 13);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (19, N'https://product.hstatic.net/1000141988/product/hat_mac_ca_uc_farmers_fine_foods_180_g__i0018730___2__06e1345d81054c09bc9dfe0b260db04f_1024x1024.jpg', 13);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (20, N'https://product.hstatic.net/1000141988/product/xoai_say_deo_farmers_fine_foods_100_g__i0018795__1bbc0fa280cb4eb08b1c234a72fdedf4_1024x1024.jpg', 14);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (21, N'https://product.hstatic.net/1000141988/product/xoai_say_deo_farmers_fine_foods_100_g__i0018795___2__1760403b30ea492fa8b5a057345bd5fa_1024x1024.jpg', 14);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (22, N'https://product.hstatic.net/1000141988/product/xoai_say_deo_farmers_fine_foods_100_g__i0018795___3__95e87c2f4ad74be19c4d4d0dd5b8587d_1024x1024.jpg', 14);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (23, N'https://product.hstatic.net/1000141988/product/tra_len_men_star__kombucha_vi_cam_dao_250ml_592f4a6ebbea49598d24a274abd03063_1024x1024.jpg', 20);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (24, N'https://product.hstatic.net/1000141988/product/star_kombucha_-_cam_dao_3938c11b31b44fefb0be21bdd7028558_1024x1024.jpg', 20);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (25, N'https://product.hstatic.net/1000141988/product/rau_hung_lui_vietgap_1_6d13a43a3c144a3f8db97c737396614c_1024x1024.png', 24);
INSERT [dbo].[ProductImages] ([Id], [ImageUrl], [ProductId]) VALUES (26, N'https://product.hstatic.net/1000141988/product/rau_hung_lui_vietgap_49dd2de629c34bc892cc9a0c628a63ea_1024x1024.png', 24);

SET IDENTITY_INSERT [dbo].[ProductImages] OFF;
