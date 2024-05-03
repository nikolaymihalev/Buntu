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
});