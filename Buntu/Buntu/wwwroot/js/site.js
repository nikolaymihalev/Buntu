// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
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
                var postImage = $('.like-image-'+postId); // Find the post image element
                postImage.attr('src', '/images/likes/' + variant + '.png');
            }
        });
    });

    $('.unlike-btn').click(function () {
        var postId = $(this).data('post-id');
        $.ajax({
            url: '/Post/Home/',
            type: 'GET',
            success: function (response) {
                var postImage = find('.like-image'); // Find the post image element
                postImage.attr('src', '~/images/blackbuttons/heart.png');
            },
            error: function (xhr, status, error) {
                // Handle error
            }
        });
    });
});