$(document).ready(function () {

    $('.create_new_board').click(function () {
        var name = $(".new_board_name").val();
        if (name.length > 1) {
            $.ajax({
                url: '/Board/Create/?name=' + name,
                success: function (data) {
                    var result = '<li id=board-' + data + '>' +
                        '<a data-ajax="true" data-ajax-mode="replace" data-ajax-update="#results" href="/Home/GetBoard/' + data + '">' + name + '</a>' +
                        '</li>';
                    $(".qwerty").before(result);
                    $('#board-' + data).trigger('click');
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
                        var result = '<div class="col-md-3" id="' + data + '">' +
                            '<article class="widget">' +
                            '<header class="widget__header one-btn">' +
                            '<div class="widget__title">' +
                            '<i class="pe-7f-menu pe-rotate-90"></i><h3>' + name + '</h3>' +
                            '</div>' +
                            '<div class="widget__config" >' +
                            '<a href="#"><i class="pe-7f-refresh"></i></a>' +
                            '</div >' +
                            '</header >' +
                            '<div class="widget__content widget__grid filled pad20">' +
                            '<div class="ui-widget ui-corner-all">' +
                            '<table id="table-' + data + '">' +
                            '                               ' +
                            '</table>' +
                            '<input id="name_new_card-' + data + '" type="text" placeholder="Name"/>' +
                            '<input id="description-' + data + '" type="text" placeholder="Description"/>' +
                            '<input id="' + data + '" class="create_card" type="button" value="Create Card"/>' +
                            '</div >' +
                            '</div >' +
                            '</article >' +
                            '</div >';

                        $("#name_new_list").before(result);
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
    
});