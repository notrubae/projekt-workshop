# projekt-workshop
========================
===== Team members =====
========================

- Daniel Falat
- Ivan Rosancic
- Martin Smolek

=================================
===== Program specification =====
=================================

Sønderborg’s library aims to launch a digital platform to manage and share its diverse digital media collection. The system should support multiple
types of media, including:
I E‑books with information about their title, author, language, number of pages, year of publication and ISBN. Users can view, download and
read them.
I Movies with information about their title, director, genres, release year, language and duration. Users can watch and download them.
I Songs with information about their title, composer, singer, genre, file type, duration and language. Users can play and download them.
I Video‑games with information about their title, genre, publisher, release year and supported platforms. Users can download, play and
eventually complete them.
I Apps with information about their title, version, publisher, supported platforms and file size. Users can download and execute them
I Podcasts with information about their title, release year, host(s), guest(s), episode number and language. Users can download and listen to
an episode and complete it.
I Images with information about their title, resolution, file format, file size and date taken. Users can download and display an image
Users should be able to borrow all media items, and only users who have borrowed an item may rate it.
The system must also support three categories of users: Admin, Employee and Borrower. For each of these the system needs to know the name, age
and social security number. As a starting point, user authentication is not required. However on startup, the program should ask the user to identify
their role.
I Borrower interact with the collection by listing items by type, selecting and previewing details, rating items, and performing actions specific
to the media type.
I Employee is responsible for managing the collection with the ability to add or remove media items
I Admin has all of an Employee’s rights and can additionally manage Borrowers and Employees. Management covers viewing, creating,
deleting, updating the personal information of users.
The supported actions should be made available to all user categories in a clear and structured way.
The console interface should guide the user with clear instructions and validate all inputs. Errors or invalid actions should not pass this filter. The
design should anticipate growth through extensibility, ensuring that new media types or user roles can be added without disrupting existing
functionality

===================================
===== Functional Requirements =====
===================================

The system must support these media types:
E-book, Movie, Song, Video-game, App, Podcast, Image.

Each media type must store its specific attributes.

All media items must support:
• preview/view
• download
• borrow
• rating (only by borrowers who borrowed it)
• type-specific actions (read/watch/play/execute/etc.)

The system must support three user roles: Admin, Employee, Borrower.

All users must have: name, age, social security number.

On program startup, user chooses their role (no authentication).

Borrowers can:
• list media by type
• view details
• borrow
• rate (only borrowed items)
• perform media-specific actions

Employees can add/remove media items.

Admins can do everything an Employee can, plus:
• view/create/update/delete Borrowers and Employees.

All user interactions must be available through a structured console UI.
All input must be validated; invalid actions must be blocked.
System must be extensible for future media types and user roles.

=======================================
===== Non-functional Requirements =====
=======================================

Extensibility: Must allow adding new media types without rewriting core logic.
Maintainability: Separation of concerns (media management, user management, UI).
Usability: Console UI with clear instructions and error messages.
Reliability: Prevent invalid borrowing, unauthorized rating, or invalid actions.
Consistency: All media types must follow a common interface or abstract class.

==============================
===== VERB–NOUN ANALYSIS =====
==============================

=== Nouns (Candidates for Classes) ===

Media (abstract)
EBook, Movie, Song, VideoGame, App, Podcast, Image
User (abstract)
Admin, Employee, Borrower
MediaCollection / Library
Rating
BorrowRecord
Platform (for games/apps)
ConsoleUI / Menu
Validator / InputValidator

=== Verbs (Candidates for Methods) ===
view / preview
download
read / watch / play / execute / listen / display
borrow
rate
addItem
removeItem
listItems
updateUser
createUser
deleteUser
manageUsers
selectRole
validateInput
complete (podcasts, video-games)

=====================
===== CRC CARDS =====
=====================

=== Class: Media (abstract) ===

Responsibilities:
Store common media attributes (title, language)
Provide preview(
Provide download()
Provide type-specific action via polymorphism
Provide borrow() support
Manage ratings

Collaborators:
Borrower
Rating
MediaCollection

=== Class: EBook ===

Responsibilities:
Store ebook-specific info (author, pages, ISBN)
Implement read()

Collaborators:
Media (parent)
Borrower

=== Class: Movie ===

Responsibilities:
Store director, genres, duration
Implement watch()

Collaborators:
Media
Borrower

=== Class: Song ===

Responsibilities:
Store composer, singer, genre, file type
Implement play()

Collaborators:
Media
Borrower

=== Class: VideoGame ===

Responsibilities:
Store publisher, release year, platforms
Implement play() and complete()

Collaborators:
Media
Borrower

=== Class: App ===

Responsibilities:
Store version, file size, supported platforms
Implement execute()

Collaborators:
Media
Borrower

=== Class: Podcast ===

Responsibilities:
Store host(s), guest(s), episode number
Implement listen() and complete()

Collaborators:
Media
Borrower

=== Class: Image ===

Responsibilities:
Store resolution, format, file size
Implement display()

Collaborators:
Media
Borrower

=== Class: User (abstract) ===

Responsibilities:
Store name, age, SSN
Provide base user behavior

Collaborators:
Admin
Employee
Borrower

=== Class: Borrower ===

Responsibilities:
List media
View details
Borrow media
Rate media
Perform type-specific actions

Collaborators:
Media
BorrowRecord
MediaCollection
Rating

=== Class: Employee ===

Responsibilities:
Add media
Remove media

Collaborators:
MediaCollection

=== Class: Admin ===

Responsibilities:
Full employee rights
Manage users (create/update/delete/list)

Collaborators:
User
MediaCollection

=== Class: MediaCollection (Library) ===

Responsibilities:
Store all media items
Add/remove/search/list media
Handle borrow records

Collaborators:
Media
BorrowRecord
Employee
Admin
Borrower

=== Class: BorrowRecord ===

Responsibilities:
Track which borrower borrowed which media
Validate rating permissions

Collaborators:
Borrower
Media

=== Class: Rating ===

Responsibilities:
Store rating value
Associate with media and borrower

Collaborators:
Media
Borrower
BorrowRecord

=== Class: ConsoleUI ===

Responsibilities:
Display menus based on role
Collect input
Route actions to controllers

Collaborators:
User
MediaCollection
Validator

=== Class: Validator ===

Responsibilities:
Validate user input
Prevent invalid actions

Collaborators:
ConsoleUI
