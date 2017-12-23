   create table ForbiddenCombination (
        Id BIGINT not null,
       ProductFromId BIGINT not null,
       ProductToId BIGINT not null,
       primary key (Id)
    )

    create table Settings (
        Id BIGINT not null,
       MaxSugarCount INT not null,
       SugarId BIGINT not null,
       primary key (Id)
    )

    create table Composition (
        Id BIGINT not null,
       Note VARCHAR(1000) not null,
       Price DECIMAL(19,5) not null,
       primary key (Id)
    )

    create table Combination (
        Id BIGINT not null,
       ProductFromId BIGINT not null,
       ProductToId BIGINT not null,
       Required BIT not null,
       primary key (Id)
    )

    create table Product (
        Id BIGINT not null,
       Name VARCHAR(1000) not null,
       Ord INT not null,
       Price DECIMAL(19,5) not null,
       ProductType INT not null,
       primary key (Id)
    )

    alter table ForbiddenCombination 
        add constraint ForbiddenCombination_ProductFrom_FK 
        foreign key (ProductFromId) 
        references Product

    alter table ForbiddenCombination 
        add constraint ForbiddenCombination_ProductTo_FK 
        foreign key (ProductToId) 
        references Product

    alter table Settings 
        add constraint Settings_Product_FK 
        foreign key (SugarId) 
        references Product

    alter table Combination 
        add constraint Combination_ProductFrom_FK 
        foreign key (ProductFromId) 
        references Product

    alter table Combination 
        add constraint Combination_ProductTo_FK 
        foreign key (ProductToId) 
        references Product


INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (1, 0, 'Вода',		20,		0)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (2, 0, 'Эспрессо',	50,		1)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (3, 0, 'Латте',		60,		2)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (4, 0, 'Капучино',	70,		3)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (5, 0, 'Чай черный',	25,		4)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (6, 0, 'Чай зелёный', 25,		5)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (7, 1, 'Молоко',		10,		6)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (8, 1, 'Сироп',		5,		7)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (9, 1, 'Сахар',		3,		8)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (10, 2, 'Хлеб',		10,		9)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (11, 2, 'Булочка',	15,		10)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (12, 2, 'Чипсы',		34,		11)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (13, 2, 'Печенье',	29,		12)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (14, 3, 'Ветчина',	15,		13)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (15, 3, 'Сыр',		10,		14)
INSERT [Product] (Id, ProductType, Name, Price, Ord) VALUES (16, 3, 'Джем',		7,		15)

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

INSERT [Composition] (Id, Note, Price) VALUES (1, 'Комплекс: 1 напиток с любой добавкой + 1 еда с любой добавкой на выбор',  90)

INSERT [Settings] (Id, MaxSugarCount, SugarId) VALUES (1, 5, 9);

INSERT [ForbiddenCombination](Id, ProductFromId, ProductToId) VALUES (1, 14, 16);
INSERT [ForbiddenCombination](Id, ProductFromId, ProductToId) VALUES (2, 15, 16);