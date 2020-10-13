function DeleteUser(Id) {
    debugger;
    var result = confirm('Are you sure you wish to delete this record?');
    if (result) {
        $.ajax({
            url: '/Index/Delete?id=' + Id,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            async: false,
            success: function (data) {
                window.reload();
                //$("#addUser").hide();
                //$("#addUser").addClass('hide');
            }

        });
    }

}