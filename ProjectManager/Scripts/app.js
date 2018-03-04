$(document).ready(function () {

    $('.create_new_board').click(function () {
        var name = $(".new_board_name").val();
        if (name.length > 1) {
            $.ajax({
                url: '/Board/Create/?name=' + name,
                success: function (data) {
                    var result = '<li id=board-' + data + '>' +
                        '<a data-ajax="true" data-ajax-mode="replace" id="board-'+data+'" data-ajax-update="#results" href="/Board/GetBoard/' + data + '">' + name + '</a>' +
                        '</li>';
                    $(".qwerty").before(result);
                }
            })
        }
    })

    $('#results').on('click', '#create', function () {
            var id = $(".main-header").attr("id");
            var name = $("#name_new_list").val();
            if (name.length > 1) {
                $.ajax({
                    url: '/TaskList/Create/?name=' + name + '&id=' + id,
                    success: function (data) {
                        var result = '<div class="col-md-3 taskList-'+data+'" id="' + data + '">' +
                            '<article class="widget">' +
                            '<header class="widget__header one-btn">' +
                            '<div class="widget__title">' +
                            '<i class="pe-7f-menu pe-rotate-90"></i><h3>' + name + '</h3>' +
                            '</div>' +
                            '<div class="widget__config" >' +
                            '<a  href=""><i id="' + data +'" class="pe-7f-refresh delete_list"></i></a>' +
                            '</div >' +
                            '</header >' +
                            '<div class="widget__content widget__grid filled pad20">' +
                            '<div class="ui-widget ui-corner-all">' +
                            '<table id="table-' + data + '">' +
                            '                               ' +
                            '</table>' +
                            '<input id="name_new_card-' + data + '" class="form-control" type="text" placeholder="Name"/>' +
                            '<input id="description-' + data + '" class="form-control" type="text" placeholder="Description"/>' +
                            '<input id="' + data + '" class="create_card btn" type="button"  value="Create Card"/>' +
                            '</div >' +
                            '</div >' +
                            '</article >' +
                            '</div >';
                        
                        $("#name_new_list_").before(result);
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
                        var result = '<tr id="card-' + data + '">' +
                            '<th>' + name + ': </th>' +
                            '<th>' + description + '</th>' +
                            '</tr>';

                        $('#table-' + id).append(result);
                    }
                })
            }
        });

    $('#results').on('click', '.delete_list', function () {
        var listId = $(".delete_list").attr("id");
        var id = $(".main-header").attr("id");
        $.ajax({
            url: '/TaskList/Delete/?id=' + id + '&listId=' + listId,
            success: function (data) {
                if (data == 0) {
                    $(".taskList-" + listId).remove();
                }
            }
        })
    });
    
});