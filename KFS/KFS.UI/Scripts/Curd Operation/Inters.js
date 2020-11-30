/// <reference path="../jquery-3.5.1.min.js" />

$(document).ready(function() {
    loadData();
});

var interObj = {
    Id: null,
    First_Name: null,
    Last_Name: null,
    College: null,
};

function loadData() {
    var interlist = $("#interdata");
    interlist.empty();
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44399/api/InterList',
            dataType: 'json',
            success: function (data) {
                $.each(data, function (index, val) {
                    var rows = "<th scope='row'>" + (index + 1) + "</th><td>" + val.First_Name + "</td ><td>" + val.Last_Name + "</td><td>" + val.College + "</td><td><button  type='button' class='btn btn-primary' data-toggle='modal' data-target='#updateintern' onclick='edit(" + val.Id + ")' >Update</button></td><td><button type='button'class='btn btn-danger'onclick='Delete(" + val.Id + ")'>Delete</button></td>";
                    interlist.append('<tr>' + rows + '</tr>');
                });
            }
        });
}

function AddInter() {
    if ($("#FirstName").val == null) {
        alert("Please enter first name");
    }
    else if ($("#LastName").val == null)
    {
        alert("Please enter last  name");
    }
    else if ($("#college").val == null)
    {
        alert("Please enter college  name");
    }
    else
    {
        
            interObj.First_Name= $('#FirstName').val(),
            interObj.Last_Name= $('#LastName').val(),
            interObj.College=$('#college').val(),
            
        
        $.ajax({
            url: 'https://localhost:44399/api/RegisterInter',
            data: JSON.stringify(interObj),
            type: "POST",
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            
            success: function (result) {
                $('#FirstName').val("");
                $('#LastName').val("");
                $('#college').val("");
                loadData();
               
            },
            error: function (errormessage) {
                console.log(errormessage.responseText);
            }
        });
    }
}
function Delete(id) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "https://localhost:44399/api/RemoveIntern?id="+id,
            type: "Delete",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                console.log(errormessage.responseText);
            }
        });
    }  
}
function Reset() {
    $('#FirstName').val("");
    $('#LastName').val("");
    $('#college').val("");
}

function edit(id) {
    $.ajax({
        url: "https://localhost:44399/api/InterDetails?id=" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            interObj.Id = id;
            $('#updateFirstName').val(result.First_Name);
            $('#updateLastName').val(result.Last_Name);
            $('#updatecollege').val(result.College);
        },
        error: function (errormessage) {
            console.log(errormessage.responseText);
        }
    });
}
function UpdateInter()
{
    if ($("#updateFirstName").val == null)
    {
        alert("Please enter first name");
    }
    else if ($("#updateLastName").val == null)
    {
        alert("Please enter last  name");
    }
    else if ($("#updatecollege").val == null)
    {
        alert("Please enter college  name");
    }
    else
    {

            interObj.First_Name = $('#updateFirstName').val(),
            interObj.Last_Name = $('#updateLastName').val(),
            interObj.College = $('#updatecollege').val(),


            $.ajax({
                url: 'https://localhost:44399/api/UpdateInterInfo',
                data: JSON.stringify(interObj),
                type: "PUT",
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',

                success: function (result) {
                    $('#updateFirstName').val("");
                    $('#updateLastName').val("");
                    $('#updatecollege').val("");
                    loadData();

                },
                error: function (errormessage) {
                    console.log(errormessage.responseText);
                }
           });
         }
}