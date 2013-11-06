-- Initial Database Install Scripts
--create Database aSchool
drop table AcademicTerm
drop table Course
drop table MappingDesignation
drop table AcademicPath
drop table CourseOffering
drop table CourseLocation
drop table CourseDependency
drop table AcademicPathMapping

Go

create Table AcademicTerm
(
	AcademicTermID int NOT NULL IDENTITY
		constraint pk_academicTermID primary key clustered,
	EndDate datetime NOT NULL,
	StartDate datetime NOT NULL,
	Term varchar(20)NOT NULL,
	WeeksDuration int NOT NULL
)
create Table Course
(
	CourseID int NOT NULL IDENTITY
		constraint pk_courseID primary key clustered,
	ClassHourPerWeek int NOT NULL,
	CourseName varchar(75) NOT NULL,
	CourseNumber varchar(5) NOT NULL,
	Credits decimal(3, 1) NOT NULL,
	SemesterOffered varchar(6)NOT NULL,
	Status varchar (20) NOT NULL,
	Term int NOT NULL
)
create Table MappingDesignation
(
	MappingDesignationID int NOT NULL IDENTITY
		constraint pk_mappingDesignationID primary key clustered,
	Description varchar(75) NOT NULL, 
	Mapping varchar(75) NOT NULL
)
create Table AcademicPath
(
	AcademicPathID int NOT NULL IDENTITY
		constraint pk_academicPathID primary key clustered,
	Description varchar(75) NOT NULL,
	Designation bit NOT NULL,
	PathName varchar(75) NOT NULL,
	RequiredCredits int NOT NULL
)
create Table CourseOffering
(
	CourseOfferingID int NOT NULL IDENTITY
		constraint pk_academicID primary key clustered,
	CourseID int NOT NULL
		constraint fk_courseOfferingToCourse references Course(CourseID),
	AcademicTermID int NOT NULL
		constraint fk_courseOfferingToAcademicTerm references AcademicTerm(AcademicTermID),
	SectionName varchar(20) NOT NULL
)
create Table CourseLocation
(
	CourseLocationID int NOT NULL IDENTITY
		constraint pk_courseLocationID primary key clustered,
	CourseOfferingID int NOT NULL
		constraint fk_courseLocationToCourseOffering references CourseOffering(CourseOfferingID),
	DurationInMinutes int NOT NULL,
	FirstClass datetime NOT NULL,
	RoomNumber varchar(20) NOT NULL
)
create Table CourseDependency
(
	CourseDependencyID int NOT NULL IDENTITY
		constraint pk_courseDependencyID primary key clustered,
	Connection varchar(75) NOT NULL,
	CourseID int NOT NULL
		constraint fk_courseDependencyToCourse references Course(CourseID),
	DependsOnCourseID int NULL
		constraint fk_courseToCourseDependency references Course(CourseID),
	Relationship varchar(75) NULL,
)

create Table AcademicPathMapping
(
	AcademicPathMappingID int NOT NULL IDENTITY
		constraint pk_academicPathMappingID primary key clustered,
	AcademicPathID int NOT NULL
		constraint fk_academicPathMappingToAcademicPath references AcademicPath(AcademicPathID),
	CourseID int NOT NULL
		constraint fk_academicPathMappingToCourse references Course(CourseID),
	MappingDesignationID int NOT NULL
		constraint fk_academicPathMappingToMappingDesignation references MappingDesignation(MappingDesignationID)
		
)
