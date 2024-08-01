create table MasterEmployee(
	EmployeeID int Primary key,
	FirstName varchar(50) Not null,
	LastName varchar(50) Not null,
	DateOfBirth date Not null,
	Designation varchar(50) Not null,
	Salary decimal(10,2) not null,
	);

	select * from MasterEmployee;

create table MasterDepartment(
	 DepartmentID int Primary key,
	 DepartmentName varchar(50) not null,
	 );

	select * from MasterDepartment;

create table EmployeeDepartment(
	EmployeeID int,
	DepartmentID int,
	FOREIGN KEY (EmployeeID)REFERENCES MasterEmployee(EmployeeID),
	FOREIGN KEY (DepartmentID)REFERENCES MasterDepartment(DepartmentID),
	PRIMARY KEY (EmployeeID,DepartmentID));

	select * from EmployeeDepartment;