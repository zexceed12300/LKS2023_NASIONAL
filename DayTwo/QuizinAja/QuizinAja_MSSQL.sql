CREATE DATABASE [QuizinAja]
GO
USE [QuizinAja]
GO

CREATE TABLE [User]
(
	[ID]					INT					NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	[Username]				VARCHAR(200)		NOT NULL,
	[FullName]				VARCHAR(200)		NOT NULL,
	[DateOfBirth]			DATE				NOT NULL,
	[Password]				VARCHAR(200)		NOT NULL
);

CREATE TABLE [Quiz]
(
	[ID]					INT					NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	[UserID]				INT					NOT NULL,
	[Name]					VARCHAR(200)		NOT NULL,
	[Code]					VARCHAR(200)		NOT NULL,
	[Description]			TEXT				NOT NULL,
	[CreatedAt]				DATETIME			NOT NULL

	CONSTRAINT FK_Quiz_User_UserID FOREIGN KEY ([UserID]) REFERENCES [User]([ID])
);

CREATE TABLE [Question]
(
	[ID]					INT					NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	[QuizID]				INT					NOT NULL,
	[Question]				TEXT				NOT NULL,
	[OptionA]				VARCHAR(200)		NOT NULL,
	[OptionB]				VARCHAR(200)		NOT NULL,
	[OptionC]				VARCHAR(200)		NOT NULL,
	[OptionD]				VARCHAR(200)		NOT NULL,
	[CorrectAnswer]			VARCHAR(200)		NOT NULL,

	CONSTRAINT FK_Question_Quiz_QuizID FOREIGN KEY ([QuizID]) REFERENCES [Quiz]([ID])
);

CREATE TABLE [Participant]
(
	[ID]					INT					NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	[QuizID]				INT					NOT NULL,
	[ParticipantNickname]	VARCHAR(200)		NOT NULL,
	[ParticipationDate]		DATETIME			NOT NULL,
	[TimeTaken]				INT					NOT NULL,

	CONSTRAINT FK_QuizParticipant_Quiz_QuizID FOREIGN KEY ([QuizID]) REFERENCES [Quiz]([ID])
);

CREATE TABLE [ParticipantAnswer]
(
	[ID]					INT					NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	[ParticipantID]			INT					NOT NULL,
	[QuestionID]			INT					NOT NULL,
	[Answer]				VARCHAR(200)		NOT NULL,

	CONSTRAINT FK_QuizParticipantAnswer_Participant_ParticipantID FOREIGN KEY ([ParticipantID]) REFERENCES [Participant]([ID]),
	CONSTRAINT FK_QuizParticipantAnswer_Question_QuestionID FOREIGN KEY ([QuestionID]) REFERENCES [Question]([ID])
);




INSERT INTO [User] ([Username], [FullName], [Password], [DateOfBirth]) VALUES ('mahdi', 'Mahdi Jokar', '1234', '2003-12-18');
INSERT INTO [User] ([Username], [FullName], [Password], [DateOfBirth])
VALUES
    ('johndoe', 'John Doe', 'secret123', '1990-05-15'),
    ('sarahsmith', 'Sarah Smith', 'pass1234', '1985-12-10'),
    ('mikejones', 'Mike Jones', 'mypass@2023', '1992-08-25'),
    ('emilywilson', 'Emily Wilson', 'ilovecoding', '1988-03-02'),
    ('chrisbrown', 'Chris Brown', 'myP@ssw0rd', '1995-11-30'),
    ('lindajohnson', 'Linda Johnson', 'summer2023', '1999-06-20'),
    ('samroberts', 'Sam Roberts', 'sam12345', '1980-07-12'),
    ('annawilliams', 'Anna Williams', 'anna@2023', '1975-04-28'),
    ('markthompson', 'Mark Thompson', 'thompson123', '1991-09-05'),
    ('lisamartin', 'Lisa Martin', 'lisaPwd!', '1997-01-18');


INSERT INTO [Quiz] ([UserID], [Name], [Code], [Description], [CreatedAt])
VALUES
    (1, 'History Quiz', 'HIST101', 'Test your knowledge of historical events and figures.', GETDATE()),
    (2, 'Science Quiz', 'SCI202', 'Explore the wonders of the natural world with this science quiz.', GETDATE()),
    (3, 'Math Challenge', 'MATH123', 'A math quiz that will put your problem-solving skills to the test.', GETDATE()),
    (4, 'Literature Quiz', 'LIT202', 'Test your knowledge of classic literature and authors.', GETDATE()),
    (5, 'Geography Quiz', 'GEOG101', 'Discover the world through this geography quiz.', GETDATE()),
    (6, 'Music Trivia', 'MUSIC303', 'A fun quiz for music enthusiasts to test their knowledge.', GETDATE()),
    (7, 'Movie Buff Quiz', 'FILM101', 'Test your knowledge of popular movies and actors.', GETDATE()),
    (8, 'Language Quiz', 'LANG456', 'Challenge your language skills with this quiz.', GETDATE()),
    (9, 'Art and Culture Quiz', 'ART101', 'Explore the world of art and culture in this quiz.', GETDATE()),
    (10, 'Sports Quiz', 'SPORTS202', 'Test your sports knowledge with this exciting quiz.', GETDATE());


INSERT INTO [Question] ([QuizID], [Question], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer])
VALUES
    (1, 'Who wrote the Declaration of Independence for the United States?', 'Thomas Jefferson', 'George Washington', 'John Adams', 'Benjamin Franklin', 'Thomas Jefferson'),
    (1, 'What was the name of the ship that carried the Pilgrims to America in 1620?', 'Mayflower', 'Santa Maria', 'Endeavour', 'Nina', 'Mayflower'),
    (1, 'In which year did World War I begin?', '1914', '1939', '1945', '1917', '1914'),
    (1, 'Who is known for famously saying, "I have a dream" in his 1963 speech?', 'Martin Luther King Jr.', 'Abraham Lincoln', 'Winston Churchill', 'John F. Kennedy', 'Martin Luther King Jr.'),
    (1, 'What is the historic significance of the year 1776 in the United States?', 'Declaration of Independence', 'Civil War', 'Revolutionary War', 'Constitutional Convention', 'Declaration of Independence');

-- Insert questions for the "Science Quiz"
INSERT INTO [Question] ([QuizID], [Question], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer])
VALUES
    (2, 'What is the chemical symbol for gold?', 'Au', 'Ag', 'Fe', 'Hg', 'Au'),
    (2, 'Which planet is known as the "Red Planet"?', 'Mars', 'Venus', 'Jupiter', 'Saturn', 'Mars'),
    (2, 'What is the process by which plants make their own food using sunlight?', 'Photosynthesis', 'Respiration', 'Fermentation', 'Transpiration', 'Photosynthesis'),
    (2, 'What is the smallest prime number?', '2', '1', '3', '5', '2'),
    (2, 'Which gas do plants absorb from the atmosphere and release oxygen during photosynthesis?', 'Carbon Dioxide', 'Oxygen', 'Nitrogen', 'Hydrogen', 'Carbon Dioxide');

-- Insert questions for the "Math Challenge"
INSERT INTO [Question] ([QuizID], [Question], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer])
VALUES
    (3, 'What is the square root of 144?', '12', '14', '16', '18', '12'),
    (3, 'Simplify the expression: 2x + 3x', '5x', '6x', '4x', '7x', '5x'),
    (3, 'What is the sum of the first 5 prime numbers?', '28', '12', '15', '18', '28'),
    (3, 'If a = 5 and b = 7, what is the value of 2a - 3b?', '-1', '1', '2', '4', '-1'),
    (3, 'What is the result of 8 * 9?', '72', '64', '80', '81', '72');

-- Insert questions for the "Literature Quiz"
INSERT INTO [Question] ([QuizID], [Question], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer])
VALUES
    (4, 'Who wrote "Pride and Prejudice"?', 'Jane Austen', 'Charlotte Bront ', 'Emily Bront ', 'Leo Tolstoy', 'Jane Austen'),
    (4, 'In which novel does the character Holden Caulfield appear?', 'The Catcher in the Rye', 'To Kill a Mockingbird', '1984', 'Moby-Dick', 'The Catcher in the Rye'),
    (4, 'Which Shakespearean play features the character Macbeth?', 'Macbeth', 'Romeo and Juliet', 'Othello', 'Hamlet', 'Macbeth'),
    (4, 'Who is the author of "1984"?', 'George Orwell', 'Aldous Huxley', 'Ray Bradbury', 'J.K. Rowling', 'George Orwell'),
    (4, 'Which novel features the character Jay Gatsby?', 'The Great Gatsby', 'The Catcher in the Rye', 'To Kill a Mockingbird', 'Moby-Dick', 'The Great Gatsby');

-- Insert questions for the "Geography Quiz"
INSERT INTO [Question] ([QuizID], [Question], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer])
VALUES
    (5, 'Which mountain is the tallest in the world?', 'Mount Everest', 'K2', 'Kangchenjunga', 'Lhotse', 'Mount Everest'),
    (5, 'What is the capital of Japan?', 'Tokyo', 'Seoul', 'Beijing', 'Bangkok', 'Tokyo'),
    (5, 'Which country is known as the "Land of the Rising Sun"?', 'Japan', 'China', 'Korea', 'Thailand', 'Japan'),
    (5, 'Which river flows through Cairo, the capital of Egypt?', 'Nile', 'Amazon', 'Mississippi', 'Yangtze', 'Nile'),
    (5, 'What is the largest desert in the world?', 'Sahara Desert', 'Gobi Desert', 'Atacama Desert', 'Arabian Desert', 'Sahara Desert');

-- Insert questions for the "Music Trivia"
INSERT INTO [Question] ([QuizID], [Question], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer])
VALUES
    (6, 'Who is known as the "Queen of Pop"?', 'Madonna', 'Beyonc ', 'Adele', 'Taylor Swift', 'Madonna'),
    (6, 'Which band released the album "Abbey Road"?', 'The Beatles', 'Led Zeppelin', 'Pink Floyd', 'The Rolling Stones', 'The Beatles'),
    (6, 'What instrument did Jimi Hendrix famously play?', 'Electric Guitar', 'Drums', 'Piano', 'Violin', 'Electric Guitar'),
    (6, 'Which music genre originated in Jamaica?', 'Reggae', 'Hip-Hop', 'Country', 'Rock', 'Reggae'),
    (6, 'Who is known as the "King of Rock and Roll"?', 'Elvis Presley', 'Michael Jackson', 'Bob Dylan', 'Frank Sinatra', 'Elvis Presley');

INSERT INTO [Question] ([QuizID], [Question], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer])
VALUES
    (7, 'Who directed the movie "Pulp Fiction"?', 'Quentin Tarantino', 'Martin Scorsese', 'Steven Spielberg', 'Alfred Hitchcock', 'Quentin Tarantino'),
    (7, 'Which film is often considered the first full-length feature film in cinema history?', 'The Birth of a Nation', 'Gone with the Wind', 'The Wizard of Oz', 'Citizen Kane', 'The Birth of a Nation'),
    (7, 'Who played the role of Jack Dawson in the movie "Titanic"?', 'Leonardo DiCaprio', 'Brad Pitt', 'Tom Hanks', 'Johnny Depp', 'Leonardo DiCaprio'),
    (7, 'In which movie does the character Darth Vader first appear?', 'Star Wars: Episode IV - A New Hope', 'The Empire Strikes Back', 'Return of the Jedi', 'The Phantom Menace', 'Star Wars: Episode IV - A New Hope'),
    (7, 'Which film won the Academy Award for Best Picture in 1994?', 'Forrest Gump', 'Pulp Fiction', 'Schindler''s List', 'The Shawshank Redemption', 'Forrest Gump');

-- Insert questions for the "Language Quiz"
INSERT INTO [Question] ([QuizID], [Question], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer])
VALUES
    (8, 'Which language is the most widely spoken in the world?', 'Mandarin Chinese', 'English', 'Spanish', 'Arabic', 'Mandarin Chinese'),
    (8, 'What is the official language of France?', 'French', 'German', 'Italian', 'Spanish', 'French'),
    (8, 'What is the official language of Russia?', 'Russian', 'Ukrainian', 'Kazakh', 'Armenian', 'Russian'),
    (8, 'What is the official language of India?', 'Hindi', 'English', 'Bengali', 'Tamil', 'Hindi'),
    (8, 'What is the most widely spoken native language in Brazil?', 'Portuguese', 'Spanish', 'English', 'French', 'Portuguese');

-- Insert questions for the "Art and Culture Quiz"
INSERT INTO [Question] ([QuizID], [Question], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer])
VALUES
    (9, 'Which artist is known for painting "Starry Night"?', 'Vincent van Gogh', 'Leonardo da Vinci', 'Pablo Picasso', 'Claude Monet', 'Vincent van Gogh'),
    (9, 'Who sculpted the statue of "David"?', 'Michelangelo', 'Leonardo da Vinci', 'Donatello', 'Raphael', 'Michelangelo'),
    (9, 'Which art movement is known for its use of bold colors and geometric shapes?', 'Cubism', 'Impressionism', 'Renaissance', 'Abstract Expressionism', 'Cubism'),
    (9, 'Which ancient civilization is known for creating the Terracotta Army?', 'China', 'Egypt', 'Greece', 'Rome', 'China'),
    (9, 'Who is the author of the famous painting "Mona Lisa"?', 'Leonardo da Vinci', 'Pablo Picasso', 'Vincent van Gogh', 'Claude Monet', 'Leonardo da Vinci');

-- Insert questions for the "Sports Quiz"
INSERT INTO [Question] ([QuizID], [Question], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer])
VALUES
    (10, 'In which sport is the term "slam dunk" commonly used?', 'Basketball', 'Soccer', 'Tennis', 'Golf', 'Basketball'),
    (10, 'Which country is famous for its contribution to the sport of cricket?', 'England', 'Brazil', 'USA', 'Japan', 'England'),
    (10, 'In which Olympic event do athletes compete in a decathlon?', 'Athletics', 'Swimming', 'Gymnastics', 'Cycling', 'Athletics'),
    (10, 'What is the distance of a standard marathon race in kilometers?', '42.195 kilometers', '26.2 miles', '10 kilometers', '50 kilometers', '42.195 kilometers'),
    (10, 'Which sport is played on a rectangular field with a ball and a goal at each end?', 'Soccer', 'Baseball', 'Hockey', 'Volleyball', 'Soccer'),
    (10, 'What is the highest possible break in a standard game of snooker?', '147', '180', '100', '90', '147'),
    (10, 'Which country won the 2018 FIFA World Cup?', 'France', 'Brazil', 'Germany', 'Argentina', 'France'),
    (10, 'Who is the all-time leading scorer in the NBA?', 'Kareem Abdul-Jabbar', 'LeBron James', 'Michael Jordan', 'Kobe Bryant', 'Kareem Abdul-Jabbar'),
    (10, 'Which country has won the most Olympic gold medals in the history of the games?', 'United States', 'China', 'Russia', 'Germany', 'United States'),
    (10, 'What is the official ball used in a game of table tennis?', 'Ping Pong Ball', 'Tennis Ball', 'Squash Ball', 'Golf Ball', 'Ping Pong Ball'),
    (10, 'In which sport is the term "birdie" commonly used?', 'Golf', 'Badminton', 'Tennis', 'Cricket', 'Golf'),
    (10, 'What is the maximum number of players on a standard volleyball team?', '6', '7', '5', '8', '6');


INSERT INTO [Participant] ([QuizID], [ParticipantNickname], [ParticipationDate], [TimeTaken]) VALUES (1, 'Andi123', GETDATE(), 124);
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer]) VALUES (1, 1, 'Thomas Jefferson');
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer]) VALUES (1, 2, 'Mayflower');
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer]) VALUES (1, 3, '1914');
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer]) VALUES (1, 4, 'Martin Luther King Jr.');
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer]) VALUES (1, 5, 'Declaration of Independence');

INSERT INTO [Participant] ([QuizID], [ParticipantNickname], [ParticipationDate], [TimeTaken]) VALUES (1, 'Budi321', GETDATE(), 55);
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer]) VALUES (2, 1, 'George Washington');
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer]) VALUES (2, 2, 'Mayflower');
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer]) VALUES (2, 3, '1914');
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer]) VALUES (2, 4, 'Martin Luther King Jr.');
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer]) VALUES (2, 5, 'Revolutionary War');


-- Insert participant data
INSERT INTO [Participant] ([QuizID], [ParticipantNickname], [ParticipationDate], [TimeTaken])
VALUES
    (1, 'Cathy456', GETDATE(), 90),
    (1, 'David789', GETDATE(), 75);

-- Insert participant answers for Cathy456
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (3, 1, 'Thomas Jefferson'),
    (3, 2, 'Mayflower'),
    (3, 3, '1914'),
    (3, 4, 'Martin Luther King Jr.'),
    (3, 5, 'Declaration of Independence');

-- Insert participant answers for David789
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (4, 1, 'George Washington'),
    (4, 2, 'Mayflower'),
    (4, 3, '1914'),
    (4, 4, 'Martin Luther King Jr.'),
    (4, 5, 'Revolutionary War');


-- Insert participant data for Science Quiz (QuizID 2)
INSERT INTO [Participant] ([QuizID], [ParticipantNickname], [ParticipationDate], [TimeTaken])
VALUES
    (2, 'Ella555', GETDATE(), 105),
    (2, 'Frank888', GETDATE(), 60);

-- Insert participant answers for Ella555 (Science Quiz)
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (5, 6, 'Au'),
    (5, 7, 'Mars'),
    (5, 8, 'Photosynthesis'),
    (5, 9, '2'),
    (5, 10, 'Carbon Dioxide');

-- Insert participant answers for Frank888 (Science Quiz)
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (6, 6, 'Ag'),
    (6, 7, 'Venus'),
    (6, 8, 'Respiration'),
    (6, 9, '3'),
    (6, 10, 'Oxygen');

-- Insert participant data for Math Challenge (QuizID 3)
INSERT INTO [Participant] ([QuizID], [ParticipantNickname], [ParticipationDate], [TimeTaken])
VALUES
    (3, 'Grace777', GETDATE(), 85),
    (3, 'Henry999', GETDATE(), 70);

-- Insert participant answers for Grace777 (Math Challenge)
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (7, 11, '12'),
    (7, 12, '5x'),
    (7, 13, '28'),
    (7, 14, '-1'),
    (7, 15, '72');

-- Insert participant answers for Henry999 (Math Challenge)
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (8, 11, '14'),
    (8, 12, '4x'),
    (8, 13, '15'),
    (8, 14, '1'),
    (8, 15, '64');

-- Insert participant data for Literature Quiz (QuizID 4)
INSERT INTO [Participant] ([QuizID], [ParticipantNickname], [ParticipationDate], [TimeTaken])
VALUES
    (4, 'Olivia111', GETDATE(), 95),
    (4, 'Liam222', GETDATE(), 80);

-- Insert participant answers for Olivia111 (Literature Quiz)
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (9, 16, 'Jane Austen'),
    (9, 17, 'The Catcher in the Rye'),
    (9, 18, 'Macbeth'),
    (9, 19, 'George Orwell'),
    (9, 20, 'The Great Gatsby');

-- Insert participant answers for Liam222 (Literature Quiz)
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (10, 16, 'Charlotte Bront '),
    (10, 17, 'Moby-Dick'),
    (10, 18, 'Romeo and Juliet'),
    (10, 19, 'Aldous Huxley'),
    (10, 20, 'The Catcher in the Rye');

-- Insert participant data for History Quiz (QuizID 1)
INSERT INTO [Participant] ([QuizID], [ParticipantNickname], [ParticipationDate], [TimeTaken])
VALUES
    (1, 'Emma246', GETDATE(), 85),
    (1, 'James369', GETDATE(), 72),
    (1, 'Sophia481', GETDATE(), 93),
    (1, 'William602', GETDATE(), 78);

-- Insert participant answers for Emma246 (History Quiz)
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (11, 1, 'George Washington'),
    (11, 2, 'Endeavour'),
    (11, 3, '1917'),
    (11, 4, 'Winston Churchill'),
    (11, 5, 'Civil War');

-- Insert participant answers for James369 (History Quiz)
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (12, 1, 'John Adams'),
    (12, 2, 'Santa Maria'),
    (12, 3, '1945'),
    (12, 4, 'Abraham Lincoln'),
    (12, 5, 'Revolutionary War');

-- Insert participant answers for Sophia481 (History Quiz)
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (13, 1, 'Benjamin Franklin'),
    (13, 2, 'Nina'),
    (13, 3, '1939'),
    (13, 4, 'John F. Kennedy'),
    (13, 5, 'Constitutional Convention');

-- Insert participant answers for William602 (History Quiz)
INSERT INTO [ParticipantAnswer] ([ParticipantID], [QuestionID], [Answer])
VALUES
    (14, 1, 'Thomas Jefferson'),
    (14, 2, 'Mayflower'),
    (14, 3, '1914'),
    (14, 4, 'Martin Luther King Jr.'),
    (14, 5, 'Declaration of Independence');