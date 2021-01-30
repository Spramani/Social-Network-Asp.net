function search_pro(e) {
    console.log($(e).val());
    $.ajax({
        url: "/NewsFeed/search_porduct?s_text=" + $(e).val(),
    }).done(function (data) {
        if ($('#search_input').val() != "") {
            if (data != "[]") {
                var jData = JSON.parse(data);
                console.log(data);
                var html = "</li>";
                $(jData).each(function () {
                    html += "<tr><td><a href='/ProfileTimeline?passuserId=" + this.id + "'><img src='" + this.user_profilephoto + "' class='rounded-circle' style='height: 50px; width: 50px;' /></a></td> <td>&nbsp&nbsp&nbsp</td><td><a href='/ProfileTimeline?passuserId=" + this.id + "'><b>" + this.user_name + "</b></br>" + this.user_name_id + "</a></td></tr>" ;
                });
                html += "</table>";
                $('.show_search').html(html);
            } else {
                $('.show_search').html("<center><h3>No search result found </h3></center>");
            }
        } else {
            $('.show_search').html("");
        }
    });
}

