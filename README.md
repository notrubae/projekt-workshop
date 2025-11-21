# projekt-workshop

## Team members

* Daniel Falat
* Ivan Rosančić
* Martin Smolek

---

# Program specification

Sønderborg’s library aims to launch a digital platform to manage and share its digital media collection.
The system supports the following media types:

* E-books: title, author, language, number of pages, publication year, ISBN
* Movies: title, director, genres, release year, language, duration
* Songs: title, composer, singer, genre, file type, duration, language
* Video-games: title, genre, publisher, release year, supported platforms
* Apps: title, version, publisher, supported platforms, file size
* Podcasts: title, release year, hosts, guests, episode number, language
* Images: title, resolution, file format, file size, date taken

Users can borrow media items, and only borrowers who borrowed an item may rate it.

Supported user roles:

* Borrower: browse, preview, borrow, rate, perform actions
* Employee: add and remove media items
* Admin: all employee rights + manage users (view/create/update/delete)

Console interface must validate all input and guide the user clearly.
The system must be extensible to support new media types or user roles.

---

# Functional Requirements

* Support media types: E-book, Movie, Song, Video-game, App, Podcast, Image
* Each media type stores its own attributes
* All media support:

  * preview/view
  * download
  * borrow
  * rating (borrowers only)
  * action specific to type
* User roles: Admin, Employee, Borrower
* All users have: name, age, social security number
* Role selection at startup
* Borrowers:

  * list media
  * view details
  * borrow
  * rate borrowed media
  * perform actions
* Employees: add/remove media
* Admins: full management of users and media
* Console UI must validate input
* System must be extensible

---

# Non-functional Requirements

* Extensibility: new media types and roles can be added
* Maintainability: clear separation of concerns
* Usability: clear console prompts and feedback
* Reliability: block invalid or unauthorized actions
* Consistency: shared abstract Media structure

---

# Verb–Noun Analysis

## Nouns

* Media (abstract), EBook, Movie, Song, VideoGame, App, Podcast, Image
* User (abstract), Admin, Employee, Borrower
* MediaCollection, Rating, BorrowRecord
* Platform, ConsoleUI, Validator

## Verbs

* view, preview
* download
* read, watch, play, execute, listen, display
* borrow
* rate
* addItem, removeItem
* listItems
* updateUser, createUser, deleteUser, manageUsers
* selectRole
* validateInput
* complete

---

# CRC Cards

## Media (abstract)

Responsibilities:

* Store basic media attributes
* Preview
* Download
* Type-specific action
* Manage ratings

Collaborators: Borrower, Rating, MediaCollection

## EBook

Responsibilities: author, pages, ISBN, read()
Collaborators: Media, Borrower

## Movie

Responsibilities: director, genres, duration, watch()
Collaborators: Media, Borrower

## Song

Responsibilities: composer, singer, genre, play()
Collaborators: Media, Borrower

## VideoGame

Responsibilities: genre, publisher, platforms, play(), complete()
Collaborators: Media, Borrower

## App

Responsibilities: version, platforms, file size, execute()
Collaborators: Media, Borrower

## Podcast

Responsibilities: hosts, guests, episode, listen(), complete()
Collaborators: Media, Borrower

## Image

Responsibilities: resolution, format, file size, display()
Collaborators: Media, Borrower

---

## User (abstract)

Responsibilities: store name, age, SSN
Collaborators: Admin, Employee, Borrower

## Borrower

Responsibilities: list, preview, borrow, rate, perform actions
Collaborators: Media, BorrowRecord, MediaCollection, Rating

## Employee

Responsibilities: add/remove media
Collaborators: MediaCollection

## Admin

Responsibilities: full employee rights + user management
Collaborators: User, MediaCollection

---

## MediaCollection

Responsibilities: store media, add/remove/search/list, track borrow operations
Collaborators: Media, BorrowRecord, Employee, Admin, Borrower

## BorrowRecord

Responsibilities: track borrowed media
Collaborators: Borrower, Media

## Rating

Responsibilities: store rating value
Collaborators: Media, Borrower, BorrowRecord

## ConsoleUI

Responsibilities: display menus, handle input
Collaborators: User, MediaCollection, Validator

## Validator

Responsibilities: input validation
Collaborators: ConsoleUI
