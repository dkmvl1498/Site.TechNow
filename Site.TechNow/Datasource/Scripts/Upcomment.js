var data = {
    idParent = idParent,
    Name = Name,
    Email = Email,
    Comment = Comment
};

$("#btnCmt").click(function () {
    $.ajax
        ({
        method: "Post",
        url: "Home/addComment",
        data: data,
        success: function (result) {
            if (result.Result == 'True') {
                alert("d m ok");
                $(".mainCmt").load('/Home/containerDetail');
                return true;
            }
            else {
                alert("co loi say ra");
                return false;
            }
        }
    })
})