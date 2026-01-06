(function () {

    "use strict";

    angular.module("umbraco")
        .controller("Our.Umbraco.Blocks.Picker", function ($scope, $controller, editorService) {

            var vm = this;

            vm.active = false;

            // find the first MultiNodeTreePicker property
            $scope.model = getPropertyByEditor($scope.block.content, "Umbraco.MultiNodeTreePicker");

            // extend content picker controller
            angular.extend(vm, $controller("Umbraco.PropertyEditors.ContentPickerController", { $scope: $scope }));

            vm.openPicker = function () {
                // set active state
                vm.active = true;

                // open controller picker instance
                $scope.openCurrentPicker();

                // override picker submit
                $scope.currentPicker.submit = (model) => vm.closePicker($scope.currentPicker.callback(model.selection));

                // override picker close
                $scope.currentPicker.close = vm.closePicker;
            };

            vm.closePicker = function (callback) {
                // process callback
                if (callback) {
                    callback();
                }

                // remove empty block
                if (!$scope.model.value) {
                    $scope.block.delete();
                }

                // close picker dialog
                editorService.close();

                // reset active state
                vm.active = false;
            };

            vm.$onInit = function () {
                // open picker for new blocks
                if (!$scope.model.value) {
                    vm.openPicker();
                }
            }

            function getPropertyByEditor(model, editor) {
                return model?.variants?.flatMap(v => v.tabs?.flatMap(t => t.properties || []) || []).find(p => p.editor === editor);
            }

            return vm;

        });

})();