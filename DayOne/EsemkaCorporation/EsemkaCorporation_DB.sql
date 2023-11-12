CREATE DATABASE [EsemkaCorporation]
GO
USE [EsemkaCorporation]
GO

CREATE TABLE [job_level](
	id					INT				NOT NULL	IDENTITY,
	[name]				VARCHAR(200)	NOT NULL,
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
)

CREATE TABLE department(
	id					INT				NOT NULL	IDENTITY,
	[name]				VARCHAR(200)	NOT NULL,
	abbreviation		VARCHAR(10)		NOT NULL,
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
)

CREATE TABLE job(
	id					INT				NOT NULL	IDENTITY,
	department_id		INT				NOT NULL,
	job_level_id		INT				NOT NULL,
	supervisor_job_id	INT,
	[name]				VARCHAR(200)	NOT NULL,
	head_count			INT				NOT NULL,
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
	FOREIGN KEY (department_id) REFERENCES [department](id),
	FOREIGN KEY (job_level_id) REFERENCES [job_level](id),
	FOREIGN KEY (supervisor_job_id) REFERENCES [job](id),
)

CREATE TABLE employee(
	id					INT				NOT NULL	IDENTITY,
	[name]				VARCHAR(200)	NOT NULL,
	email				VARCHAR(200)	NOT NULL	UNIQUE,
	[password]			VARCHAR(64)		NOT NULL,
	phone_number		VARCHAR(200)	NOT NULL,
	[hire_date]			DATETIME		NOT NULL,
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
)

CREATE TABLE position(
	id					INT				NOT NULL	IDENTITY,
	job_id				INT				NOT NULL,
	employee_id			INT				NOT NULL,
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
	FOREIGN KEY (job_id) REFERENCES [job](id),
	FOREIGN KEY (employee_id) REFERENCES [employee](id),
)

CREATE TABLE mutation(
	id					INT				NOT NULL	IDENTITY,
	job_id				INT				NOT NULL,
	employee_id			INT				NOT NULL,
	[status]			VARCHAR			NOT NULL,	--'Pending', 'In Process', or 'Approved'
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
	FOREIGN KEY (job_id) REFERENCES [job](id),
	FOREIGN KEY (employee_id) REFERENCES [employee](id),
)

CREATE TABLE promotion(
	id					INT				NOT NULL	IDENTITY,
	job_id				INT				NOT NULL,
	employee_id			INT				NOT NULL,
	[status]			VARCHAR			NOT NULL,	--'Pending', 'In Process', or 'Approved'
	created_at			DATETIME		NOT NULL	DEFAULT CURRENT_TIMESTAMP,
	deleted_at			DATETIME,
	PRIMARY KEY (id),
	FOREIGN KEY (job_id) REFERENCES [job](id),
	FOREIGN KEY (employee_id) REFERENCES [employee](id),
)


INSERT INTO job_level ([name]) VALUES ('Staff')
INSERT INTO job_level ([name]) VALUES ('Officer')
INSERT INTO job_level ([name]) VALUES ('Supervisor')
INSERT INTO job_level ([name]) VALUES ('Manager')
INSERT INTO job_level ([name]) VALUES ('Director')

INSERT INTO department ([name],abbreviation) VALUES ('Information Technology', 'IT')
INSERT INTO department ([name],abbreviation) VALUES ('Operations', 'OPR')
INSERT INTO department ([name],abbreviation) VALUES ('Finance and Accounting', 'FnA')
INSERT INTO department ([name],abbreviation) VALUES ('Procurement', 'PROC')
INSERT INTO department ([name],abbreviation) VALUES ('Human Capital', 'HC')
INSERT INTO department ([name],abbreviation) VALUES ('Board of Management', 'BoM')

INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (6, 5, NULL, 'Director', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (6, 5, 1, 'Vice Director 1', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (6, 5, 1, 'Vice Director 2', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (5, 4, 2, 'Human Capital Manager', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (5, 3, 4, 'Career Management and Assesment Section Head', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (5, 3, 4, 'Career Planning Section Head', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (5, 3, 4, 'Career Scholarship Section Head', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (5, 2, 5, 'Career Management and Assesment Officer', 2)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (5, 2, 6, 'Career Planning Section Officer', 2)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (5, 1, 5, 'Career Management and Assesment Staff', 5)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (5, 1, 6, 'Career Planning Section Staff', 5)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (4, 4, 3, 'Procurement Manager', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (4, 4, 12, 'Procurement Manager - Associate', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (4, 3, 13, 'Procurement Controller Section Head', 2)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (4, 3, 13, 'Procurement Outlet Section Head', 3)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (4, 2, 15, 'Procurement Outlet Officer', 2)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (4, 2, 14, 'Purchasing Officer', 3)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (4, 2, 14, 'Warehouse Officer', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (3, 4, 3, 'Finance and Accounting Manager', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (3, 3, 19, 'Chief Accountant', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (3, 3, 19, 'Finance Section Head', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (3, 2, 20, 'Accountant Officer', 2)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (3, 2, 21, 'Finance Officer', 2)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (3, 1, 20, 'Accountant Staff', 5)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 4, 25, 'Front Office Manager - Associate', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 4, 1, 'Operations Manager', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 3, 25, 'Content and Multimedia Section Head', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 3, 26, 'Customer Service Section Head', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 3, 26, 'Front Office Section Head', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 3, 25, 'Internationalization Activity Section Head', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 3, 25, 'Research Center Section head', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 2, 25, 'Back Office Administrator', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 2, 28, 'Customer Service Officer', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 2, 25, 'Internationalization Activity Officer', 2)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 2, 25, 'Research Center Officer', 2)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 2, 26, 'Vendor Service Officer', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 1, 29, 'Customer Service Staff', 5)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (2, 1, 36, 'Vendor Service Staff', 5)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (1, 4, 2, 'IT Manager', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (1, 3, 39, 'Application and Database Section Head', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (1, 3, 39, 'IT Support Section Head', 1)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (1, 2, 40, 'Application and Database Administration Officer', 2)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (1, 2, 41, 'IT Support Officer', 3)
INSERT INTO job (department_id, job_level_id, supervisor_job_id, name, head_count) VALUES (1, 1, 41, 'IT Support Staff', 5)

INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Alethea Hopewell', 'ahopewell0@people.com.cn', 'vakWN5f3cajz', '375 305 7807', '2016-07-10 05:33:51', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Rebe Penburton', 'rpenburton1@imgur.com', 'HdG8vK7FVN2e', '561 704 2428', '2020-12-06 10:17:29', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Mark Lattimore', 'mlattimore2@yahoo.co.jp', 'pwcQLGynvd8B', '621 767 9725', '2021-09-02 12:22:02', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Evangelina Beautyman', 'ebeautyman3@constantcontact.com', 'C3xss3EUwBQ8', '691 631 5176', '2021-03-04 02:49:31', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Marga Matthai', 'mmatthai4@unc.edu', 'WEJ7vX8KQfhR', '840 758 9905', '2018-09-03 18:37:05', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Dallon Petteford', 'dpetteford5@reverbnation.com', 'vgP3pdYWfuVU', '159 881 1170', '2016-06-02 23:30:54', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Marina Waud', 'mwaud6@mediafire.com', '673qKazzEDxm', '933 419 4910', '2021-01-21 19:15:38', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Gloriane Bristo', 'gbristo7@vistaprint.com', 'zfDxxunC7AVn', '845 197 8796', '2021-10-31 07:37:24', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Neila Mothersole', 'nmothersole8@nature.com', 'uYyCM5tQP9Hz', '142 564 8156', '2018-06-09 14:57:29', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('York Manby', 'ymanby9@gmpg.org', 'mrH8uQCVXayr', '587 634 3185', '2021-03-19 20:45:51', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Mozelle Noble', 'mnoblea@uiuc.edu', 'HNVtd4ZmNhP6', '258 376 9260', '2014-05-22 23:14:19', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Gennie Avramow', 'gavramowb@edublogs.org', 'm7eDnguv5hgb', '309 167 6638', '2017-01-25 06:47:39', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Micheal Frowen', 'mfrowenc@mlb.com', 'nfHCkWN9gDvY', '502 230 3208', '2021-12-21 02:45:52', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Cordell O''Loughnan', 'coloughnand@time.com', '4fAQbCfy4NFq', '239 983 9110', '2018-10-02 17:22:43', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Rossie Catto', 'rcattoe@ustream.tv', 'ns5UwLvVrEKR', '333 704 6732', '2014-05-11 06:37:48', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Jorge Stubbe', 'jstubbef@gmpg.org', 'aZ6B3chgS4xu', '993 937 8010', '2017-06-10 17:02:56', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Brenda Luton', 'blutong@vkontakte.ru', 'B2tr5CkHA4aM', '462 410 0710', '2017-09-29 23:09:55', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Gardy Friedenbach', 'gfriedenbachh@posterous.com', 'VvJ4d26NJA7L', '312 942 9682', '2017-05-04 14:02:32', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Sidonnie Trehearn', 'strehearni@examiner.com', 'Hm8FZLABdxXW', '772 149 9773', '2020-06-30 20:12:00', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Elsey Eccersley', 'eeccersleyj@networkadvertising.org', '3v7MhmF6MTgq', '124 769 4551', '2017-09-08 20:37:18', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Mill Gier', 'mgierk@baidu.com', '2JqRk7fyxZML', '567 285 1790', '2017-04-21 08:24:54', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Pauly Burras', 'pburrasl@netscape.com', 'TExD3TxaTT3J', '523 882 2655', '2014-10-18 17:03:05', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Aldon Barrett', 'abarrettm@blogspot.com', '5wrskzSPMLeB', '177 134 7058', '2020-03-10 13:48:51', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Liliane Kesteven', 'lkestevenn@businessweek.com', 'PLZnmA3kxpRH', '961 974 9332', '2017-10-05 22:45:58', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Nada Klulik', 'nkluliko@cbc.ca', 'tfhK4gW8rdFB', '451 406 4096', '2013-12-24 18:38:49', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Chevalier Ezzell', 'cezzellp@forbes.com', '8UQhCwZMAHSh', '437 805 6439', '2015-09-03 00:09:37', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Marti Kennerley', 'mkennerleyq@gizmodo.com', 'YULEeA6nLhhw', '834 167 2373', '2015-12-31 00:14:07', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Goldi Riepl', 'grieplr@cafepress.com', '8brMEExHvc2w', '619 650 3229', '2020-05-28 03:57:40', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Brnaby Wardel', 'bwardels@mediafire.com', 'xjUkWw5dmb92', '487 969 0251', '2018-05-09 13:32:20', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Manon Giacoppoli', 'mgiacoppolit@wikimedia.org', 'JmvDj7jbJTKV', '385 760 0959', '2020-09-09 16:37:21', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Andi Adamson', 'aadamsonu@opera.com', 'NpbzEPkhFPw6', '691 328 6636', '2019-06-22 17:36:17', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Alastair Linwood', 'alinwoodv@ftc.gov', 's2QWe9cJZzwm', '863 132 5839', '2018-10-20 18:05:12', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Annis Threadgall', 'athreadgallw@webmd.com', 'CQJmgT6QnPrc', '260 243 6476', '2019-04-10 16:36:37', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Rayner Kinch', 'rkinchx@wisc.edu', 'W8xT5fsSjPBJ', '304 391 6138', '2016-12-02 17:29:06', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Ina Oguz', 'ioguzy@jalbum.net', 'Z4jWFZAVdQmq', '639 364 5369', '2017-08-17 00:30:10', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Page Coslitt', 'pcoslittz@people.com.cn', 'hWy63H3FY2xa', '842 807 0655', '2017-03-02 03:54:15', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Gretta Carlisle', 'gcarlisle10@goo.ne.jp', 't6kAUhS9UxAN', '428 148 1587', '2019-06-28 01:48:08', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Merilyn Ismail', 'mismail11@yahoo.com', 'KFCgtaqmge5k', '421 246 1780', '2018-02-12 20:40:50', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Ivor Futcher', 'ifutcher12@yahoo.com', 'ktrHykACTsY7', '684 417 1444', '2017-05-31 17:43:19', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Belita Breitler', 'bbreitler13@paypal.com', 'V2VXU3wsUYGv', '442 971 0720', '2015-06-27 01:34:45', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Hernando Sedman', 'hsedman14@typepad.com', 'U8czTe8kUkcu', '826 130 6412', '2018-08-03 14:18:06', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Luce Bartelli', 'lbartelli15@i2i.jp', 'zu5hBa22ZnnW', '660 701 2602', '2014-02-08 20:54:07', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Dode Deam', 'ddeam16@examiner.com', '3zYtcbHSS5j8', '495 412 9252', '2021-04-09 10:58:46', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Parrnell Iczokvitz', 'piczokvitz17@imageshack.us', 'qmeAtFXDj4hX', '380 678 5924', '2020-06-02 21:01:27', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Daryl Parkhouse', 'dparkhouse18@shinystat.com', 'W3JqMu6j5QrB', '209 391 8803', '2015-06-12 21:41:12', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Valery Mieville', 'vmieville19@pcworld.com', 'UgG8xP2UXxsx', '979 323 2018', '2020-10-16 03:03:38', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Drugi Mathonnet', 'dmathonnet1a@harvard.edu', 'dWvJRYrGKuQ8', '479 368 0365', '2021-07-10 07:26:58', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Kathrine Worwood', 'kworwood1b@goodreads.com', 'Ecyfpu3XmL2j', '638 631 1595', '2020-05-13 12:13:22', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Gerri Biddlecombe', 'gbiddlecombe1c@1und1.de', '2fSrZ7jntryD', '904 826 3981', '2020-01-13 19:49:27', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('L;urette Sandyford', 'lsandyford1d@ucla.edu', 'cMEZEnLMub9k', '666 387 8103', '2020-07-19 02:41:07', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Joane Stoller', 'jstoller1e@virginia.edu', 'gVpc6HQJtCDc', '634 599 4308', '2013-06-12 08:16:16', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Inesita Casa', 'icasa1f@buzzfeed.com', 'E9n3Zv298mmj', '436 427 3165', '2015-11-07 02:26:11', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Cord Klimashevich', 'cklimashevich1g@theatlantic.com', 'x8hYyddF9SW6', '138 876 2885', '2016-10-24 01:10:47', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Roana Bolan', 'rbolan1h@1und1.de', 'VYEfMdGkY2zZ', '170 265 0290', '2017-06-28 03:18:27', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Currey Benger', 'cbenger1i@china.com.cn', 'TbpauRf5Dzge', '111 448 2795', '2019-01-22 12:18:28', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Walton Langeren', 'wlangeren1j@ucoz.com', 'aCJSWh4kA4cg', '434 441 5643', '2021-10-22 06:48:54', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Nichole Clute', 'nclute1k@sciencedaily.com', '5twFPPpKZfrM', '916 988 6741', '2020-10-14 02:51:31', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Tilly Kayzer', 'tkayzer1l@mlb.com', 'QcH5zwAKDx42', '211 315 0678', '2020-08-11 01:21:21', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Georgie Divver', 'gdivver1m@instagram.com', 'a7XGx5vHMaC8', '477 666 7246', '2018-10-09 03:17:03', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Carin MacColgan', 'cmaccolgan1n@homestead.com', 'UeQvRVz8MNe9', '329 882 9967', '2018-04-01 09:21:46', '2023-10-19 00:01:00')
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Dolley Malley', 'dmalley1o@reddit.com', 'WFEzeP5Dyb9W', '491 671 0569', '2020-04-06 11:55:02', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Gerta Opdenort', 'gopdenort1p@ow.ly', 'CETzZwaLtV97', '476 451 2245', '2016-03-04 20:10:20', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Ernesta Siemens', 'esiemens1q@hhs.gov', 'udnYtwkCLmA3', '752 422 2329', '2017-09-27 15:21:27', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Aurora Singyard', 'asingyard1r@artisteer.com', 'G5HzvgHgNmpR', '427 296 9006', '2013-01-11 02:19:11', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Kameko Airth', 'kairth1s@usgs.gov', '8hHNMbFnLYqf', '889 605 3354', '2017-04-20 02:52:40', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Cecilla Furmagier', 'cfurmagier1t@dailymail.co.uk', 'PRzh3gfgGfgv', '328 459 5893', '2015-04-13 23:28:02', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Deeann MacNeil', 'dmacneil1u@geocities.jp', 'QnhP6ryk4ATN', '699 850 6280', '2017-03-24 09:54:01', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Leona Shenfisch', 'lshenfisch1v@vistaprint.com', 'BwbsNDmhy6KC', '826 946 8683', '2019-12-20 23:41:33', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Dionysus Bruce', 'dbruce1w@yahoo.com', 'GgLMCJhvQPg2', '451 609 4164', '2021-11-19 09:27:35', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Wilmette Press', 'wpress1x@scribd.com', '6Fvzr6PfHprx', '412 714 0212', '2016-03-12 09:03:50', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Rainer Lauret', 'rlauret1y@usatoday.com', 'YXCnMAPQmMh4', '288 143 9594', '2016-03-24 01:05:32', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Guenevere Mc Gaughey', 'gmc1z@about.com', '7Qc48acDm8bA', '735 818 0569', '2017-06-26 03:32:37', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Gherardo Dumphy', 'gdumphy20@miitbeian.gov.cn', '7ThdBQw8gamc', '982 882 0805', '2014-03-06 10:05:31', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Chris St. Louis', 'cst21@jimdo.com', 'CstxKTwYy3qU', '179 438 6515', '2013-09-22 22:25:39', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Edik Wimmer', 'ewimmer22@stanford.edu', 'nxQ7gyzpgHrL', '496 729 9260', '2019-01-09 12:33:05', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Ira Murphy', 'imurphy23@yahoo.co.jp', '8GK9KHQEA8kr', '149 236 4822', '2016-07-19 19:48:51', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Rosco Gaytor', 'rgaytor24@dropbox.com', 'EkLNY9vXszHF', '116 111 0165', '2015-06-02 22:17:12', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Desmond McCord', 'dmccord25@webs.com', 'mHV67VMbU9rN', '194 829 7439', '2015-03-16 03:17:22', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Orelle Joselson', 'ojoselson26@amazon.co.jp', 'Cr4Raz3MtFB8', '620 481 2671', '2016-03-27 00:29:18', NULL)
INSERT INTO employee ([name], email, password, phone_number, hire_date, deleted_at) VALUES ('Cristiano McKennan', 'cmckennan27@ibm.com', 'dPXpmwjAW4qd', '255 171 6533', '2018-08-29 03:27:44', NULL)

INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (1, 1, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (2, 2, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (2, 1, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (3, 3, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (3, 60, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (4, 4, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (4, 1, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (5, 5, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (6, 6, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (7, 7, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (8, 8, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (8, 61, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (9, 9, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (10, 10, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (10, 62, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (10, 63, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (10, 64, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (10, 58, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (10, 59, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (11, 11, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (11, 46, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (11, 65, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (11, 66, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (11, 67, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (12, 12, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (13, 13, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (14, 14, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (15, 15, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (15, 68, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (15, 69, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (16, 16, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (17, 17, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (18, 18, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (19, 19, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (20, 20, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (21, 21, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (22, 22, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (22, 70, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (23, 23, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (23, 71, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (24, 24, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (26, 26, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (25, 25, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (27, 27, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (28, 28, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (29, 29, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (30, 51, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (30, 30, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (31, 31, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (32, 32, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (33, 33, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (34, 34, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (34, 72, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (35, 35, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (35, 73, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (36, 36, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (37, 37, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (37, 74, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (37, 52, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (37, 53, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (37, 54, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (37, 55, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (38, 38, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (38, 56, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (38, 57, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (39, 39, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (40, 40, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (41, 41, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (42, 42, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (42, 75, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (43, 43, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (43, 76, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (43, 77, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (44, 44, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (44, 78, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (44, 79, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (44, 80, '2023-10-19 00:01:00', NULL)
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (44, 47, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (44, 48, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (44, 49, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (44, 50, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (44, 77, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (31, 25, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (38, 36, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (35, 31, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (10, 9, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (10, 65, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (11, 16, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (24, 70, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (37, 18, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (43, 41, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (44, 41, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (42, 41, '2023-10-19 00:01:00', '2023-10-19 00:01:00')
INSERT INTO position (job_id, employee_id, created_at, deleted_at) VALUES (42, 77, '2023-10-19 00:01:00', '2023-10-19 00:01:00')


-- SELECT * FROM job_level
-- SELECT * FROM department
-- SELECT * FROM job
-- SELECT * FROM employee
-- SELECT * FROM position
-- SELECT * FROM mutation
-- SELECT * FROM promotion

--DROP ALL TABLE
--EXEC SP_MSFOREACHTABLE 'DROP TABLE ?'

--DROP DATABASE
--USE MASTER
--GO
--DROP DATABASE [EsemkaCorporation]