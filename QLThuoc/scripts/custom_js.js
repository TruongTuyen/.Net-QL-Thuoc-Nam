(function ($) {
    

    $('#open_model_image').click(function (e) {
        e.preventDefault();
        $("#tabs").tabs();
        $("#image_dialog").dialog({
            width: 800,
            height: 400,
        });

    });



    $('#chosen_image').click(function (e) {
        e.preventDefault();
    });

    $('.tab-images-list img').click(function () {
        if ($(this).hasClass('chosen_img')) {
            $(this).removeClass('chosen_img');
        } else {
            $('.tab-images-list img').removeClass('chosen_img');
            $(this).addClass('chosen_img');
        }
        
    });

    $('#modal-ok').click(function (e) {
        e.preventDefault();
        $("#image_dialog").dialog("close");

        var selected_img_length = $('.tab-images-list').find('img.chosen_img').length;
        console.log('length: ' + selected_img_length);
        if (selected_img_length > 0) {
            var url = $('.tab-images-list').find('img.chosen_img').attr('src');
            if (url != '') {
                $('#input_save_image_url').val(url);
                console.log('seted value');
            }
            
        } else {
            console.log('no image selected');
        }

    });


    $('#custom_show_hide').click(function (e) {
        e.preventDefault();
        $(".tt_upload_image").toggleClass("tt_custom_show_hide");
    });

    $(document).ready(function () {
        $('.ds_thuoc').find(".4u").addClass("ádfsadfsadf");
    });

})(jQuery);