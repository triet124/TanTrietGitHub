
// Đảm bảo rằng toàn bộ tài liệu HTML đã tải xong trước khi chạy mã JavaScript.
$(document).ready(function () {

    // Sự kiện khi nút "getBtnJson" được nhấn
    $("#getBtnJson").click(function () {
        $.ajax({
            // URL của tệp JSON cần lấy dữ liệu
            url: "data.json",

            // Phương thức HTTP GET để lấy dữ liệu
            type: "GET",

            // Hàm này sẽ chạy nếu yêu cầu thành công
            success: function (data) {

                // Hiển thị dữ liệu JSON trong phần tử có ID "resultJson"
                $("#resultJson").html(JSON.stringify(data));
            },
            // Hàm này sẽ chạy nếu yêu cầu thất bại
            error: function () {

                // Hiển thị thông báo lỗi
                alert("Error loading JSON data.");
            }
        });
    });

    // Sự kiện khi nút "getBtnHtml" được nhấn
    $("#getBtnHtml").click(function () {
        $.ajax({

            // URL của tệp HTML cần lấy dữ liệu
            url: "data.html",

            // Phương thức HTTP GET để lấy dữ liệu
            type: "GET",

            // Hàm này sẽ chạy nếu yêu cầu thành công
            success: function (data) {

                // Hiển thị dữ liệu HTML trong phần tử có ID "resultHtml"
                $("#resultHtml").html(data);
            },

            // Hàm này sẽ chạy nếu yêu cầu thất bại
            error: function () {

                // Hiển thị thông báo lỗi
                alert("Error loading HTML data.");
            }
        });
    });

    // Sự kiện khi nút "getBtnText" được nhấn
    $("#getBtnText").click(function () {
        $.ajax({

            // URL của tệp văn bản cần lấy dữ liệu
            url: "data.txt",

            // Phương thức HTTP GET để lấy dữ liệu
            type: "GET",

            // Hàm này sẽ chạy nếu yêu cầu thành công
            success: function (data) {

                // Hiển thị dữ liệu văn bản trong phần tử có ID "resultText"
                $("#resultText").html(data);
            },

            // Hàm này sẽ chạy nếu yêu cầu thất bại
            error: function () {

                // Hiển thị thông báo lỗi
                alert("Error loading TEXT data.");
            }
        });
    });

    // Sự kiện khi nút "getBtnAPI" được nhấn
    $("#getBtnAPI").click(function () {
        $.ajax({

            // URL của API cần lấy dữ liệu
            url: `https://api.open-meteo.com/v1/forecast?latitude=16.1667&longitude=107.8333&hourly=temperature_2m&timezone=Asia%2FBangkok&forecast_days=1`,

            // Phương thức HTTP GET để lấy dữ liệu
            type: "GET",

            // Định dạng dữ liệu mong đợi là JSON
            dataType: "json",

            // Hàm này sẽ chạy nếu yêu cầu thành công
            success: function (data) {

                // Hiển thị khu vực múi giờ trong phần tử có class "timezone"
                $(".timezone").html(
                    "khu vực múi giờ: " + data.timezone 
                );

                // Hiển thị múi giờ trong phần tử có class "time"
                $(".time").html(
                    "múi giờ: " + data.timezone_abbreviation
                );
            },

            // Hàm này sẽ chạy nếu yêu cầu thất bại
            error: function () {

                // Hiển thị thông báo lỗi
                alert("Lỗi khi tải dữ liệu thời tiết.");
            }
        });
    
    });
});