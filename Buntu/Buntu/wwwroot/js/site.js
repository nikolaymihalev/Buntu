document.querySelector('.like-btn').addEventListener('click', function () {
    document.querySelector('.reaction-form').style.display = 'block';
});

$(document).ready(function () {
    $('.reaction-btn').click(function () {
        var postId = $(this).data('post-id');
        var variant = $(this).data('variant');
        $.ajax({
            url: '/Post/Like',
            type: 'POST',
            data: { postId: postId, variant:variant },
            success: function (response) {
                var postImage = $('.like-image-'+postId); 
                postImage.attr('src', '/images/likes/' + variant + '.png');     

                if (response.operation === "add") {
                    var likeCount = $('.post-likescount-' + postId).text();

                    var currentCount = parseInt(likeCount.substring(0, 1)) + 1;

                    $('.post-likescount-' + postId).text(currentCount + " likes");
                } 
            },
        });
    });

    $('.like-btn').click(function () {
        var postId = $(this).data('post-id');
        $.ajax({
            url: '/Post/Unlike',
            type: 'POST',
            data: { postId: postId },
            success: function (response) {
                if (response.operation === "delete") {
                    var postImage = $('.like-image-' + postId);
                    postImage.attr('src', '/images/blackbuttons/heart.png');
                    $('.reaction-form').css('display', 'none');

                    var likeCount = $('.post-likescount-' + postId).text();

                    var currentCount = parseInt(likeCount.substring(0, 1)) - 1;

                    $('.post-likescount-' + postId).text(currentCount + " likes");
                }        
            }
        });
    });

    $('.comment-button').click(function () {
        var postId = $(this).data('post-id');
        var username = $(this).data('username');
        var commentValue = $('#comment-text-' + postId).val();
        var button = $(this);

        $.ajax({
            url: '/Post/Comment',
            type: 'POST',
            data: { postId: postId, content: commentValue },
            success: function (response) {
                if (response.success === true) {
                    var commentContent = ": " + commentValue;
                    $('.last-comment-content-' + postId).text(commentContent);
                    $('.last-comment-username-' + postId).text(username);
                }    
                $('#comment-text-' + postId).val("");
                button.css('display', 'none');
            }
        });
    });

    $('.favorite-btn').click(function () {
        var postId = $(this).data('post-id');

        $.ajax({
            url: '/Post/Favorite',
            type: 'POST',
            data: { postId: postId },
            success: function (response) {
                var postImage = $('.favorite-img-' + postId);

                if (response.success === true) {
                    postImage.attr('src', '/images/blackbuttons/favorite_pressed.png');
                } else {
                    postImage.attr('src', '/images/blackbuttons/favorite.png');
                }
            }
        });
    });

    $('.all-comments-btn').click(function () {
        var postId = $(this).data('post-id');

        $.ajax({
            data: { postId: postId },
            success: function (response) {
                var commentsForm = $('.all-comments-form-' + postId);
                if (commentsForm.is(":hidden")) {
                    commentsForm.css('display', 'block');
                }
                else {
                    commentsForm.css('display', 'none');
                }
            }
        });
    });

    $('.all-likes-btn').click(function () {
        var postId = $(this).data('post-id');

        $.ajax({
            data: { postId: postId },
            success: function (response) {
                var commentsForm = $('.all-likes-form-' + postId);
                if (commentsForm.is(":hidden")) {
                    commentsForm.css('display', 'block');
                }
                else {
                    commentsForm.css('display', 'none');
                }
            }
        });
    });

    $('.likes-variant-btn').click(function () {
        var postId = $(this).data('post-id');
        var variant = $(this).data('likes-variant');

        $.ajax({
            data: { postId: postId },
            success: function (response) {                
                hideLikesVariantContent(variant)
                $('.likes-content-' + variant.toLowerCase()).css('display', 'block');
            }
        });
    });

    $('.follow-btn').click(function () {
        var userId = $(this).data('user-id');
        var button = $(this);
        $.ajax({
            url: '/User/Follow',
            type: 'POST',
            data: { userId: userId,},
            success: function (response) {
                if (response.success === true) {
                    button.text("Unfollow");
                    button.css('background', 'gray');

                    var followersCount = $('.followers-text').text();

                    var currentCount = parseInt(followersCount.substring(0, 1)) + 1;

                    $('.followers-text').text(currentCount + " followers");
                } else {
                    button.text("Follow");
                    button.css('background', 'lightcoral');

                    var followersCount = $('.followers-text').text();

                    var currentCount = parseInt(followersCount.substring(0, 1)) - 1;

                    $('.followers-text').text(currentCount + " followers");
                }                
            },
        });
    });

    $('.followers-btn').click(function () {
        $.ajax({
            success: function (response) {

                var followersForm = $('.user-followers-form');
                if (followersForm.is(":hidden")) {
                    followersForm.css('display', 'block');
                }
                else {
                    followersForm.css('display', 'none');
                }
            }
        });
    });
});

function toggleCommentVisibility(textarea) {
    var commentText = textarea.value;
    var commentBtn = textarea.nextElementSibling;

    if (commentText.trim() !== "") {
        commentBtn.style.display = "block"; 
    } else {
        commentBtn.style.display = "none";
    }
}

function hideLikesVariantContent(variant) {
    if (variant === "Thumb") {

        $('.likes-content-love').css('display', 'none');
        $('.likes-content-haha').css('display', 'none');
        $('.likes-content-wow').css('display', 'none');
        $('.likes-content-sad').css('display', 'none');
        $('.likes-content-angry').css('display', 'none');

    } else if (variant === "Love") {

        $('.likes-content-thumb').css('display', 'none');
        $('.likes-content-haha').css('display', 'none');
        $('.likes-content-wow').css('display', 'none');
        $('.likes-content-sad').css('display', 'none');
        $('.likes-content-angry').css('display', 'none');

    } else if (variant === "Haha") {

        $('.likes-content-thumb').css('display', 'none');
        $('.likes-content-love').css('display', 'none');
        $('.likes-content-wow').css('display', 'none');
        $('.likes-content-sad').css('display', 'none');
        $('.likes-content-angry').css('display', 'none');

    } else if (variant === "Wow") {

        $('.likes-content-thumb').css('display', 'none');
        $('.likes-content-love').css('display', 'none');
        $('.likes-content-haha').css('display', 'none');
        $('.likes-content-sad').css('display', 'none');
        $('.likes-content-angry').css('display', 'none');

    } else if (variant === "Sad") {

        $('.likes-content-thumb').css('display', 'none');
        $('.likes-content-love').css('display', 'none');
        $('.likes-content-haha').css('display', 'none');
        $('.likes-content-wow').css('display', 'none');
        $('.likes-content-angry').css('display', 'none');

    } else if (variant === "Angry") {

        $('.likes-content-thumb').css('display', 'none');
        $('.likes-content-love').css('display', 'none');
        $('.likes-content-haha').css('display', 'none');
        $('.likes-content-wow').css('display', 'none');
        $('.likes-content-sad').css('display', 'none');
    }
}