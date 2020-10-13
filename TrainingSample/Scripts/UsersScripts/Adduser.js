function InsertUser() {
    debugger;
    var userName = $("#AName").val();
    var Email = $("#ALat").val();
    var Address = $("#ALong").val();
    var image = $("#image").html();
    //var image = $("#image").get(0).files;
    //var data = new FormData();
    //data.append(image);
     var imagenBase64 = $("#pImageBase64").html();
    var carLicense = $("#cLicense").val()
    $.ajax({
        url: '/Index/InsertuS',
        type: 'POST',
        data: JSON.stringify({
            FullName: userName,
            UserEmail: Email,
            Address: Address,
            ProfilePic: imagenBase64,
            CarLicense: carLicense
            

        }),
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            $("#addUser").hide();
            //$("#addUser").addClass('hide');
            
        }

    });
    
}
function encodeImagetoBase64(element) {
    var file = element.files[0];
    var reader = new FileReader();
    reader.onloadend = function () {
        $("#image").attr("src", reader.result);
        $("#pImageBase64").html(reader.result);

    }
    reader.readAsDataURL(file);
}
