var app = angular.module("myApp", []);
app.filter('phoneFormat', function () {
    return function (phoneNumber) {
        // regex bắt lỗi
        var phoneRegex2 = /((09|03|07|08|05)+([0-9]{8})\b)/g;
        // so sánh chuỗi nhập vào và regex
        if (!phoneRegex2.test(phoneNumber)) {
            return "Số điện thoại không hợp lệ";
        } else {
            return phoneNumber.substring(0, 3)
                + "." + phoneNumber.substring(3, 6)
                + "." + phoneNumber.substring(6, 10);
        }
    };
});

app.controller('myCtrl', ['$scope', 'phoneFormatFilter', function ($scope, phoneFormatFilter) {
    $scope.validatePhone = function () {
        //tạo mảng để chứa thông tin từ các biến
        $scope.myroots = {}
        //tạo các thành phần trong mảng
        $scope.myroots.password = "";
        $scope.myroots.email = "";
        //tạo biến và gán giá trị của phoneNumber vào 
        var phoneNumber = $scope.phoneNumber;
        // áp dụng filter phoneFormat để định dạng số điện thoại và gán kết quả vào biến $scope.content
        $scope.content = phoneFormatFilter(phoneNumber);
    };
}]);

//Tạo một directive có tên là stcModal
app.directive('stcModal', function () {
    return {
        //Định nghĩa cho directive đó là một Element HTML
        restrict: 'E',
        //Nơi lưu trữ các biến của directive
        scope: { 
            // sử dụng "@" để liên kết giá trị chuỗi trực tiếp
            title: '@', 
            //content, myroot được gán với một biến bên trong controller
            content: '=', 
            myroot: '='
        },
        //Đường dẫn template dẫn tới html sẽ được hiển thị ở stcModal
        templateUrl: './index.html',
        link: function (scope, element, attrs) {
        }
    };
});