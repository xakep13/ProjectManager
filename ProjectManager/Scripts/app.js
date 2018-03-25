﻿$(document).ready(function () {

    $('body').on('click', '.add_user', function () {
        var boardId = $('.main-header').attr('id');
        var userId = $(this).attr("id");
        console.log("hello");
        $.ajax({
            url: '/Board/AddUser/?boardId=' + boardId+'&userid='+userId,
            success: function (data) {
                if (data == 1) {
                    location.reload();
                } else {
                    alert("something wrong!");
                }
            }
        });
    }); 

    $('body').on('click', '.remove_user', function () {
        var boardId = $('.main-header').attr('id');
        var userId = $(this).attr("id");
        console.log("hello");
        $.ajax({
            url: '/Board/RemoveUser/?boardId=' + boardId + '&userid=' + userId,
            success: function (data) {
                if (data == 1) {
                    location.reload();
                } else {
                    alert("something wrong!");
                }
            }
        });
    });

    $('.wrapper').on('click', '.create_board', function () {
        var name = $(".new_board_name").val();
        if (name.length > 1) {
            $.ajax({
                url: '/Board/Create/?name=' + name,
                success: function (data) {
                    var result = '<li class="col-xs-10 board-' + data + '">' +
                                    '<a data-ajax="true" data-ajax-mode="replace" id="board-' + data + '" data-ajax-update="#results" href="/Board/GetBoard/' + data + '">' + name + '</a>' +
                                 '</li>' +
                                    '<a><li class="col-xs-2"><i id="' + data + '" class="pe-7s-close delete_board"></i></li></a>'
                    $(".qwerty").before(result);
                    location.reload();
                }
            })
        }
    });

    $('.wrapper').on('click', '.delete_board', function () {
        var count = $('.count').attr('id');
        if (count > 1) {
            if (confirm('Are you sure you want to remove this board?')) {
                var boardId = $(this).attr("id");
                $.ajax({
                    url: '/Board/Delete/?boardId=' + boardId,
                    success: function (data) {
                        if (data == 0) {
                            $('.board-' + boardId).remove();
                            location.reload();
                        }
                    }
                })
            }
        } else alert("You can't delete last board");
    });

    $('#results').on('click', '.create_list', function () {
        var id = $(".main-header").attr("id");
        var name = $("#name_new_list").val();
        if (name.length > 1) {
            $.ajax({
                url: '/TaskList/Create/?name=' + name + '&id=' + id,
                success: function (data) {
                    var result = '<div class="col-md-3 taskList-' + data + '" id="' + data + '">' +
                        '<article class="widget">' +
                        '<header class="widget__header one-btn">' +
                        '<div class="widget__title">' +
                        '<i class="pe-7f-menu pe-rotate-90"></i><h3>' + name + '</h3>' +
                        '</div>' +
                        '<div class="widget__config" >' +
                        '<a ><i id="' + data + '" class="pe-7s-close delete_list"></i></a>' +
                        '</div >' +
                        '</header >' +
                        '<div class="widget__content widget__grid filled pad20">' +
                        '<div class="ui-widget ui-corner-all" id="table-' + data + '">' +
                        '<br class="name_new_card-' + data + '" /><div class="col-xs-9 ">'+
                        '<input id="name_new_card-' + data + '" class="form-control" type="text" placeholder="Name"/>' +
                        '</div><div class="col-xs-3">'+
                        '<input id="' + data + '" class="create_card btn" type="button"  value="New"/>' +
                        '</div><br />'+
                        '</div >' +
                        '</div >' +
                        '</article >' +
                        '</div >';

                    $("#name_new_list_").before(result);
                }
            })
        }
    });

    $('#results').on('click', '.delete_list', function () {
        if (confirm('Are you sure you want to remove this list into the board?')) {
            var listId = $(this).attr("id");
            $.ajax({
                url: '/TaskList/Delete/?listId=' + listId,
                success: function (data) {
                    if (data == 0) {
                        $(".taskList-" + listId).remove();
                    }
                }
            })
        }
    });

    $('#results').on('click', '.create_card', function () {
        var id = $(this).attr("id");
        var name = $("#name_new_card-" + id).val();
        var description = $("#description-" + id).val();
        if (name.length > 1) {
            $.ajax({
                url: '/Card/Create/?name=' + name + '&id=' + id + '&description=' + description,
                success: function (data) {
                    var result = '<div class="col-xs-10" id="card-' + data + '"  >' +
                        '<input id="data" type="text" readonly class="form-control" value="' + name + '" /></div>' +
                        '<div class="col-xs-2" id="card-' + data + '"><a><i id="' + data + '" class="pe-7f-close delete_card"></i></a></div> <br id="card-' + data + '" /> <br id="card-' + data + '" />';

                    $('.name_new_card-' + id).before(result);
                }
            })
        }
    });
    
    $('#results').on('click', '.delete_card', function () {
        if (confirm('Are you sure you want to remove this card into the list?')) {
            var cardId = $(this).attr("id");
            $.ajax({
                url: '/Card/Delete/?cardId=' + cardId,
                success: function (data) {
                    if (data == 0) {
                        for (var i = 0; i < 4; i++) {
                            $("#card-" + cardId).remove();
                        }
                    }
                }
            })
        }
    });

    $("#msearch").on("keyup", function () {
        var name = $(this).val();
        $.ajax({
            url: '/Home/Search/?name=' + name,
            success: function (data) {
                $('.result').empty();
                $(".result").append(data);
            }
        })
    });
});