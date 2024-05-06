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
                $('.all-comments-form-' + postId).css('display','block');
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