(function () {
    var books = BookModule.generateBooksArray(100);

    // Task 06. By a given collection of books, find the most popular author (the author with the highest number of books)
    var booksPerAuthor = _.countBy(books, function (book) {
        return book.author;
    });

    var mostPopularAuthor = {
        name: '',
        books: 0
    };

    _.map(booksPerAuthor, function (books, name) {
        if (books > mostPopularAuthor.books) {
            mostPopularAuthor.name = name;
            mostPopularAuthor.books = books;
        }
    });

    console.log(booksPerAuthor);
    console.log(mostPopularAuthor.name + ': ' + mostPopularAuthor.books);
})();