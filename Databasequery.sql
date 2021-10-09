CREATE TABLE General
(
	Id int PRIMARY KEY IDENTITY(1,1),
    [numFound] [bigint] NOT NULL,
	[start] [int] NULL,
	[maxScore] [decimal](18, 7)  NOT  NULL
)

CREATE TABLE Document
(
docid int PRIMARY KEY IDENTITY(1,1),
generalId int foreign key(generalId) references General(Id),
score decimal(18,7),
id varchar(max) ,
journal varchar(50) ,
eissn varchar(50) ,
publication_date datetime,
article_type varchar(50)
)


CREATE TABLE author_display
(
id int PRIMARY KEY IDENTITY(1,1),
author_display_name varchar(50),
docid int foreign key(docid) references Document(docid)
)
create TABLE abstract_display
(
id int PRIMARY KEY IDENTITY(1,1),
abstract_display_name varchar(MAX),
docid int foreign key(docid) references Document(docid)
)

