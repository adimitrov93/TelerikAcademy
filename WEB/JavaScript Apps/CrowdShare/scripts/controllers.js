define(['jquery', 'persisters', 'http-requester', 'underscore', 'handlebars'], function ($, persisters, httpRequester, _) {
    var Controller = (function () {
        function Controller(baseUrl) {
            this.persister = persisters.get(baseUrl);
        }
        
        Controller.prototype.loadUI = function (selector) {
            if (this.persister.isUserLoggedIn()) {
                this.loadUserUI(selector);
            }
            else {
                this.loadVisitorUI(selector);
            }
            
            this.attachUIEventHandlers(selector);
        };
        
        Controller.prototype.loadUserUI = function (selector) {
            var self = this;
            $(function () {
                $(selector).empty();

                httpRequester.getText('templates/user-ui.html').then(function (userUI) {
                    $('#wrapper').append(userUI);

                    httpRequester.getText('templates/posts-template.html').then(function (postsTempalate) {
                        var template = Handlebars.compile(postsTempalate);
                        self.persister.posts.get().then(function (posts) {
                            for (var i = 0, len = posts.length; i < len; i++) {
                                posts[i].postDate = new Date(posts[i].postDate);
                            }
                            var html = template({ posts: posts });
                            $('#posts-container').append(html);
                        });
                    });
                });
            });
        };

        Controller.prototype.loadVisitorUI = function (selector) {
            var self = this;
            $(function () {
                $(selector).empty();
                
                httpRequester.getText('templates/visitor-ui.html').then(function (visitorUI) {
                    $('#wrapper').append(visitorUI);
                    
                    httpRequester.getText('templates/posts-template.html').then(function (postsTempalate) {
                        var template = Handlebars.compile(postsTempalate);
                        self.persister.posts.get().then(function (posts) {
                            for (var i = 0, len = posts.length; i < len; i++) {
                                posts[i].postDate = new Date(posts[i].postDate);
                            }
                            var html = template({ posts: posts });
                            $('#posts-container').append(html);
                        });
                    });
                });
            });
        };

        Controller.prototype.attachUIEventHandlers = function (selector) {
            var wrapper = $(selector);
            var self = this;
            var sortByRule;
            var sortInRule;
            var itemsPerPage;
            var currentPage = 0;
            
            wrapper.on('click', '#login-btn', function () {
                var username = $('#tb-login-username').val();
                var password = $('#tb-login-password').val();
                
                self.persister.user.login(username, password).then(function () {
                    self.loadUserUI(selector);
                }, function (error) {
                    alert(error);
                });
            });

            wrapper.on('click', '#register-btn', function () {
                var tbRegisterUsername = $('#tb-register-username');
                var tbRegisterPassword = $('#tb-register-password');
                
                var username = tbRegisterUsername.val();
                var password = tbRegisterPassword.val();
                
                if (6 <= username.length && username.length <= 40) {
                    self.persister.user.register(username, password).then(function () {
                        tbRegisterUsername.val('');
                        tbRegisterPassword.val('');
                        alert('Success! You can now login!');
                    }, function (error) {
                        alert(error);
                    });
                }
                else {
                    alert('Username must be between 6 and 40 characters.');
                }
                
            });
            
            wrapper.on('click', '#logout-btn', function () {
                self.persister.user.logout().then(function () {
                    self.loadVisitorUI(selector);
                }, function (error) {
                    alert(error);
                });
            });

            wrapper.on('click', '#new-post-btn', function () {
                var tbNewPostTitle = $('#tb-new-post-title');
                var tbNewPostBody = $('#tb-new-post-body');
                
                var title = tbNewPostTitle.val();
                var body = tbNewPostBody.val();
                
                self.persister.posts.create(title, body).then(function () {
                    httpRequester.getText('templates/posts-template.html').then(function (postsTempalate) {
                        var template = Handlebars.compile(postsTempalate);
                        self.persister.posts.get().then(function (posts) {
                            for (var i = 0, len = posts.length; i < len; i++) {
                                posts[i].postDate = new Date(posts[i].postDate);
                            }

                            if (sortByRule) {
                                posts = _.sortBy(posts, function (post) {
                                    return sortByRule === 'date' ? post.postDate : post.title;
                                });
                            }

                            if (sortInRule === 'descending') {
                                posts = posts.reverse();
                            }

                            if (itemsPerPage) {
                                posts = posts.slice(currentPage * itemsPerPage, (currentPage + 1) * itemsPerPage);
                            }
                            
                            var html = template({ posts: posts });
                            $('#posts-container').empty().append(html);
                        });
                    });
                }, function (error) {
                    alert(error);
                });
            });

            wrapper.on('click', '#sort-btn', function () {
                sortByRule = $("input:radio[name=sort-by]:checked").val();
                sortInRule = $("input:radio[name=sort-in]:checked").val();

                httpRequester.getText('templates/posts-template.html').then(function (postsTempalate) {
                    var template = Handlebars.compile(postsTempalate);
                    self.persister.posts.get().then(function (posts) {
                        for (var i = 0, len = posts.length; i < len; i++) {
                            posts[i].postDate = new Date(posts[i].postDate);
                        }

                        if (sortByRule) {
                            posts = _.sortBy(posts, function (post) {
                                return sortByRule === 'date' ? post.postDate : post.title;
                            });
                        }
                        
                        if (sortInRule === 'descending') {
                            posts = posts.reverse();
                        }
                        
                        var html = template({ posts: posts });
                        $('#posts-container').empty().append(html);
                    });
                });
            });

            wrapper.on('click', '#split-btn', function () {
                itemsPerPage = $('#tb-item-per-page').val();
                
                httpRequester.getText('templates/posts-template.html').then(function (postsTempalate) {
                    var template = Handlebars.compile(postsTempalate);
                    self.persister.posts.get().then(function (posts) {
                        for (var i = 0, len = posts.length; i < len; i++) {
                            posts[i].postDate = new Date(posts[i].postDate);
                        }
                        
                        if (sortByRule) {
                            posts = _.sortBy(posts, function (post) {
                                return sortByRule === 'date' ? post.postDate : post.title;
                            });
                        }
                        
                        if (sortInRule === 'descending') {
                            posts = posts.reverse();
                        }
                        
                        if (itemsPerPage) {
                            posts = posts.slice(currentPage * itemsPerPage, (currentPage + 1) * itemsPerPage);
                        }

                        var html = template({ posts: posts });
                        $('#posts-container').empty().append(html).after('<button id="prev-btn">Prev</button><button id="next-btn">Next</button>');
                    });
                });
            });

            wrapper.on('click', '#next-btn', function () {
                currentPage++;

                httpRequester.getText('templates/posts-template.html').then(function (postsTempalate) {
                    var template = Handlebars.compile(postsTempalate);
                    self.persister.posts.get().then(function (posts) {
                        for (var i = 0, len = posts.length; i < len; i++) {
                            posts[i].postDate = new Date(posts[i].postDate);
                        }

                        if (sortByRule) {
                            posts = _.sortBy(posts, function (post) {
                                return sortByRule === 'date' ? post.postDate : post.title;
                            });
                        }

                        if (sortInRule === 'descending') {
                            posts = posts.reverse();
                        }

                        if (itemsPerPage) {
                            posts = posts.slice(currentPage * itemsPerPage, (currentPage + 1) * itemsPerPage);
                        }

                        if (posts.length !== 0) {
                            var html = template({ posts: posts });
                            $('#posts-container').empty().append(html);
                        }
                        else {
                            currentPage--;
                        }
                    });
                });
            });

            wrapper.on('click', '#prev-btn', function () {
                if (currentPage !== 0) {
                    currentPage--;                    
                }

                httpRequester.getText('templates/posts-template.html').then(function (postsTempalate) {
                    var template = Handlebars.compile(postsTempalate);
                    self.persister.posts.get().then(function (posts) {
                        for (var i = 0, len = posts.length; i < len; i++) {
                            posts[i].postDate = new Date(posts[i].postDate);
                        }

                        if (sortByRule) {
                            posts = _.sortBy(posts, function (post) {
                                return sortByRule === 'date' ? post.postDate : post.title;
                            });
                        }

                        if (sortInRule === 'descending') {
                            posts = posts.reverse();
                        }

                        if (itemsPerPage) {
                            posts = posts.slice(currentPage * itemsPerPage, (currentPage + 1) * itemsPerPage);
                        }
                        
                        var html = template({ posts: posts });                        
                        $('#posts-container').empty().append(html);
                    });
                });
            });
        };
        
        return Controller;
    })();
    
    return {
        get: function (baseUrl) {
            return new Controller(baseUrl);
        }
    }
});