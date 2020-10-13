

function EditUserDetails(Id) {
    debugger;
    $.ajax({
        url: '/Index/Edit?Id=' + Id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        async: true,
        success: function (data) {
            debugger;
            console.log(data);
            $("#gid1").val(data.UserId);
            $("#AName1").val(data.FullName);
            $("#ALat1").val(data.UserEmail);

            var sno = 0;
            var div = $('#carDetailsDiv');
            div.empty();

            data.CarLicense.forEach(function (event) {

                div.append("<label>CarLicense" + (sno + 1) + "</label>" +
                    "<input class='form-control' id='" + event.Id + "' name='cLicense1' type='text' value='" + event.CarNumberPlate + "' />");

                sno++;
            });
        }
        //$("#editUser").hide();
        //$("#editUser").addClass('hide');


    });
}


function EditUser1() {
    debugger;
    var id = $("#gid1").val();
    var name = $("#AName1").val();
    var email = $("#ALat1").val();
    
    
    //var param = new Array();
    //data.CarLicense.forEach(function (event) {
    //    //var id = element.data(event.id);

    //    //var carLicense = element.data(event.CarNumberPlate);
    //    //var id = $(event.Id).text();
    //    //var carLicense = $(event.CarNumberPlate).text();
    //    //var carLicense = $("#" + event.Id).text();
    //    //param.push(event.Id, event.CarNumberPlate)
    //    param.push(id, carLicense);

    //});
    var param = new Array();
    $("input[name='cLicense1']").each(function () {
        param.push(this.id);
    });
    var param1 = [];
    param.forEach(function (entry) {
        
        param1.push({
            id: entry,
            CarNumberPlate: $("#" + entry).val(),
           
        });
    });
    console.log(param1);
   
    $.ajax({
        url: '/Index/Edit',
        type: 'POST',
        data: JSON.stringify({
            UserId: id,
            FullName: name,
            UserEmail: email,
            CarDetails: param1

        }),
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            $("#editUser").hide();
            $("#editUser").addClass('hide');
        }

    });
}

