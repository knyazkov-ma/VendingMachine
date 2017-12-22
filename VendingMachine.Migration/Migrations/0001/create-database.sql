    create table Combination (
        Id BIGINT not null,
       ProductFromId BIGINT not null,
       ProductToId BIGINT not null,
       Required BIT not null DEFAULT(0),
       primary key (Id)
    )

    create table Product (
        Id BIGINT not null,
       Name VARCHAR(1000) not null,
       Ord INT not null DEFAULT(0),
       MaxCountPerOrder INT not null DEFAULT(1),
       Price DECIMAL(19,5) not null DEFAULT(0),
       ProductType INT not null DEFAULT(0),
       primary key (Id)
    )

	create table Composition (
        Id BIGINT not null,
       Note VARCHAR(1000) not null,
       Price DECIMAL(19,5) not null DEFAULT(0),
       primary key (Id)
    )

    alter table Combination 
        add constraint Combination_ProductFrom_FK 
        foreign key (ProductFromId) 
        references Product

    alter table Combination 
        add constraint Combination_ProductTo_FK 
        foreign key (ProductToId) 
        references Product

INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (1, 0, 'Вода',		20,		0,	1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (2, 0, 'Экспрессо',	50,		1,	1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (3, 0, 'Латте',		60,		2,	1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (4, 0, 'Капучино',	70,		3,	1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (5, 0, 'Чай черные',	25,		4,	1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (6, 0, 'Чай зелёный', 25,		5,	1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (7, 1, 'Молоко',		10,		6,	1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (8, 1, 'Сироп',		5,		7,	1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (9, 1, 'Сахар',		3,		8,	5)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (10, 2, 'Хлеб',		10,		9,	1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (11, 2, 'Булочка',	15,		10, 1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (12, 2, 'Чипсы',		34,		11, 1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (13, 2, 'Печенье',	29,		12, 1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (14, 3, 'Ветчина',	15,		13, 1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (15, 3, 'Сыр',		10,		14, 1)
INSERT [Product] (Id, ProductType, Name, Price, Ord, MaxCountPerOrder) VALUES (16, 3, 'Джем',		7,		15, 1)

INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (1, 1, 8, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (2, 1, 9, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (3, 2, 7, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (4, 2, 9, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (5, 3, 2, 1)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (6, 3, 7, 1)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (7, 3, 9, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (8, 4, 2, 1)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (9, 4, 7, 1)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (10, 4, 9, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (11, 5, 9, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (12, 6, 9, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (13, 10, 14, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (14, 10, 15, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (15, 10, 16, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (16, 11, 14, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (17, 11, 15, 0)
INSERT [Combination] (Id, ProductFromId, ProductToId, [Required]) VALUES (18, 11, 16, 0)

INSERT [Composition] (Id, Note, Price) VALUES (1, 'Комплекс: 1 напиток с любой едой + 1 напиток с любой добавкой на выбор',  90)
