/*creating database Booksdb*/
create database BooksDB

/*Setting the current db to Booksdb*/
use BooksDB

/*Creating Table Books*/
create table Books(
Book_Id int identity(1001,1) primary key not null,
Book_Name varchar(100) unique,
Author varchar(100),
Price money not null,
Book_Desc varchar(max),
Books_URL varchar(150),
Img_URL varchar(150),
Pages int ,
Publisher varchar(150),
Books_Language varchar(50),
ISBN varchar(15) unique
)

/*Inserting a sample record to books table*/
insert into books(Book_Name,Author,Price,Books_URL,Img_URL,
Pages,Publisher,Books_Language,ISBN,Book_Desc) values('The Future of Humanity','Michio Kaku',
599.00,'https://www.amazon.in/Future-Humanity-Michio-Kaku/dp/0241304849/ref=sr_1_1?s=books&rps=1&ie=UTF8&qid=1526120336&sr=1-1&refinements=p_98%3A10440597031',
'https://images-na.ssl-images-amazon.com/images/I/51t3%2BUvKqnL._SX323_BO1,204,203,200_.jpg',345,
'Allen Lane','English','0241304849',
'Human civilization is on the verge of spreading beyond Earth. More than a possibility, it is becoming a necessity: whether our hand is forced by climate change and resource depletion or whether future catastrophes compel us to abandon Earth, one day we will make our homes among the stars.
World-renowned physicist and futurist Michio Kaku explores in rich, accessible detail how humanity might gradually develop a sustainable civilization in outer space. With his trademark storytelling verve, Kaku shows us how science fiction is becoming reality: Mind-boggling developments in robotics, nanotechnology and biotechnology could enable us to build habitable cities on Mars, nearby stars might be reached by microscopic spaceships sailing through space on laser beams; and technology might one day allow us to transcend our physical bodies entirely.
With irrepressible enthusiasm and wonder, Dr. Kaku takes readers on a fascinating journey to a future in which humanity could finally fulfil its long-awaited destiny among the stars and perhaps even achieve immortality.'
)

/*Creating a sample stored procedure to insert data to books table*/
create procedure USP_InsertBooksData
@Name varchar(150),
@Author Varchar(150),
@Description varchar(max),
@Price money,
@Book_URL varchar(150),
@Img_URL varchar(150),
@Pages int,
@Publisher varchar(150),
@Language varchar(50),
@ISBN varchar(15)
as 
begin 
insert into Books
(
Book_Name,
Author,
Price,
Book_Desc,
Books_URL,
Img_URL,
Pages,
Publisher,
Books_Language,
ISBN
)values(@Name,
@Author,
@Price,
@Description,
@Book_URL,
@Img_URL,
@Pages,
@Publisher,
@Language,
@ISBN
)
end 
go

/*Creating a sample stored procedure to retrive books data from books table with bookID*/
create procedure USP_GetBooksData
@BookID int
as begin
select * from  Books where Book_Id=@BookID;
end 
go

/*Creating sample stored procedure to update books table data 
this procedure updates data which are not null */
create procedure USP_UpdateBooksData
@Name varchar(150),
@Id int,
@Author Varchar(150),
@Description varchar(max),
@Price money,
@Book_URL varchar(150),
@Img_URL varchar(150),
@Pages int,
@Publisher varchar(150),
@Language varchar(50),
@ISBN varchar(15)
as begin 
update BooksDB.dbo.Books
set Book_Name= case when @Name is not null then @Name else Book_Name end,
Author=case when @Author is not null then @Author else Author end,
Book_Desc= case when @Description is not null then @Description else Book_Desc end,
Price= case when @Price is not null then @Price else Price end,
Books_URL=case when @Book_URL is not null then @Book_URL else Books_URL end,
Img_URL=case when @Img_URL is not null then @Img_URL else Img_URL end,
Pages= case when @Pages is not null then @Pages else Pages end,
Publisher = case when @Publisher is not null then @Publisher else Publisher end,
Books_Language= case when @Language is not null then @LANGUAGE else Books_Language end,
ISBN = case when @ISBN is not null then @ISBN else ISBN end
where Book_Id=@ID;
end 
go

/*Retrive data from books table*/
select * from Books

