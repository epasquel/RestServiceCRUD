

if not exists(select * from sysobjects where name = 'Students')
begin
	create table Students(
	Codigo int identity(1,1) primary key not null,
	Nombre varchar(50),
	ApellidoPaterno varchar(100),
	ApellidoMaterno varchar(100),
	Edad int
	)
end

go


if exists(select * from sysobjects where name = 'up_saveStudent')
begin
	drop proc up_saveStudent
end

go

create proc up_saveStudent
@Nombre varchar(50),
@ApellidoPaterno varchar(100),
@ApellidoMaterno varchar(100),
@Edad INT
as
begin

insert into Students (Nombre, ApellidoPaterno, ApellidoMaterno, Edad) values (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Edad)

declare @id int
set @id = @@IDENTITY

SELECT Nombre, ApellidoPaterno, ApellidoMaterno, Edad, Codigo FROM Students where Codigo = @id

end

go

if exists(select * from sysobjects where name = 'up_updateStudent')
begin
	drop proc up_updateStudent
end

go

create proc up_updateStudent
@Codigo int,
@Nombre varchar(50),
@ApellidoPaterno varchar(100),
@ApellidoMaterno varchar(100),
@Edad int
as
begin

update Students 
set Nombre = @Nombre,
	ApellidoPaterno = @ApellidoPaterno, 
	ApellidoMaterno = @ApellidoMaterno,
	Edad = @Edad
where Codigo = @Codigo

SELECT Nombre, ApellidoPaterno, ApellidoMaterno, Edad, Codigo FROM Students where Codigo = @Codigo

end

go

if exists(select * from sysobjects where name = 'up_deleteStudent')
begin
	drop proc up_deleteStudent
end

go

create proc up_deleteStudent
@Codigo int
as
begin
	delete from Students where Codigo = @Codigo
end

go

if exists(select * from sysobjects where name = 'up_getStudentByID')
begin
	drop proc up_getStudentByID
end

go

create proc up_getStudentByID
@Codigo int
as
begin
	SELECT Nombre, ApellidoPaterno, ApellidoMaterno, Edad, Codigo FROM Students where Codigo = @Codigo
end

go

if exists(select * from sysobjects where name = 'up_getAllStudents')
begin
	drop proc up_getAllStudents
end

go

create proc up_getAllStudents
as
begin
	SELECT Nombre, ApellidoPaterno, ApellidoMaterno, Edad, Codigo FROM Students
end

go

if exists(select * from sysobjects where name = 'up_getSearchStudents')
begin
	drop proc up_getSearchStudents
end

go

create proc up_getSearchStudents
@query varchar(100)
as
begin
	SELECT Nombre, ApellidoPaterno, ApellidoMaterno, Edad, Codigo FROM Students
	WHERE Nombre like '%' + @query +'%' or ApellidoPaterno like '%' + @query + '%' OR ApellidoMaterno LIKE '%' + @query + '%'
end