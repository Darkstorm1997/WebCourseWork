var get_comments = function (item) {
    return new Promise(resolve => {
        $.getJSON("/Items/Comments/" + item, function (comments) {
            resolve(comments)
        })
    })
}

var delete_comment = function (id) {
    return new Promise(resolve => {
        $.ajax({
            url: "/api/Comments/" + id,
            type: "DELETE",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                resolve()
            }
        })
    })
}

var new_comment = function (author, content, item_id) {
    console.log(author)
    console.log(content)
    console.log(item_id)
    return new Promise(resolve => {

        var data = JSON.stringify({ "Author": author, "Content": content, "ItemId": item_id })

        console.log(data)

        $.ajax({
            url: "/api/Comments",
            type: "POST",
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                resolve()
            }
        })
    })
}

var get_searched_items = function (category, title, summery, date) {
    return new Promise(resolve => {
        $.ajax({
            type: "GET",
            url: "/Items/Search/",
            data: { category: category, header: title, summery: summery, date: date },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (items) {
                resolve(items)
            }
        });
    })
}

var get_searched_comments = function (author, content, date) {
    return new Promise(resolve => {
        $.ajax({
            type: "GET",
            url: "/api/Comments/Search/",
            data: { Author: author, Content: content, DatePosted: date },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (comments) {
                resolve(comments)
            }
        });
    })
}