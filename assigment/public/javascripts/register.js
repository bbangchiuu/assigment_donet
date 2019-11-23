$(document).ready(function () {
    
    $('#addItem').click(function (e) {

        $.ajax({
            url: "/BuyItem/AddItem", // gửi ajax đến file result.php
            type: "post", // chọn phương thức gửi là post
            dataType: "html", // dữ liệu trả về dạng text
            data: { // Danh sách các thuộc tính sẽ gửi đi
                pro_id: $('#pro_id').val(),
                quantity: $('#qty_input').val()
            },
            success: function (result) {
                console.log(result);
                $('#qty_order').empty();
                $('#qty_order').html(result);
            }
        });
        e.preventDefault();
    });
});