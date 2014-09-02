var BookModule = (function () {
    var Book = function (name, author) {
        this.name = name;
        this.author = author;
    };

    var generateBooksArray = function (count) {
        count = count || 15;

        var authors = ['J. K. Rowling', 'Stephen King', 'J. R. R. Tolkien', 'Dan Brown', 'Paulo Coelho', 'Christopher Paolini', 'Terry Pratchett', 'Terry Brooks', 'Raymond E. Feist'],
            books = [];

        for (var i = 0; i < count; i++) {
            var book = new Book('Book #' + (i + 1), authors[getRandomNumber(authors.length)]);

            books.push(book);
        }

        return books;
    };

    var getRandomNumber = function (max) {
        return Math.floor(Math.random() * max);
    };

    return {
        Book: Book,
        generateBooksArray: generateBooksArray
    };
})();