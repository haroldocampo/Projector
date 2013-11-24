var App = function() {
    this.assignments = {};
    this.persons = {};
    this.projectId = 0;
    var self = this;

    this.init = function (data) {
        self.assignments = data.modelAssignments;
        self.persons = data.modelPersons;
        self.projectId = data.modelProjectId;

        self.bindData(data);
    };

    this.bindData = function (data) {

        var assignment = function (item) {
            var thisAssignment = this;
            thisAssignment.Id = item.Id;
            thisAssignment.ProjectId = item.ProjectId;
            thisAssignment.PersonId = item.PersonId;
            thisAssignment.PersonUsername = item.PersonUsername;
        };

        var assignments = function (items) {
            var thisAssignments = this;
            thisAssignments.assignments = ko.observableArray();
            thisAssignments.removeAssignment = function () {
                $.ajax({
                    url: "/api/assignment/" + this.Id,
                    type: "DELETE",
                    error: function (e) {
                        alert('Please contact system administrator');
                    }
                });

                thisAssignments.assignments.remove(this)
            };

            $.each(items, function (index, value) {
                thisAssignments.assignments.push(new assignment(value));
                findAndRemove(self.persons, "Id", value.PersonId)
            });
        };

        var person = function (item) {
            var thisPerson = this;
            thisPerson.Id = item.Id;
            thisPerson.Name = item.FirstName + ' ' + item.LastName;
            thisPerson.Username = item.Username;
        };

        var persons = function (items) {
            var thisPersons = this;
            thisPersons.Persons = ko.observableArray();
            thisPersons.SelectedPerson = ko.observable();

            thisPersons.addAssignment = function () {
                var assignmentModel = { Id: 0, ProjectId: self.projectId, PersonId: this.SelectedPerson().Id, PersonUsername: this.SelectedPerson().Username };

                $.ajax({
                    url: "/api/assignment/",
                    type: "POST",
                    cache: false,
                    contentType: 'application/json',
                    data: JSON.stringify(assignmentModel),
                    error: function (e) {
                        alert('Please contact system administrator');
                    },
                    complete: function (m) {
                        m = JSON.parse(m.responseText);
                        assignmentModel.Id = m.Id;
                        assignmentVM.assignments.push(new assignment(assignmentModel));
                        personVM.Persons.remove(function (item) { return item.Id == assignmentModel.PersonId});
                    }
                });
            };

            $.each(items, function (index, value) {
                thisPersons.Persons.push(new person(value));
            });
        };

        var assignmentVM = new assignments(self.assignments);
        var personVM = new persons(self.persons);

        ko.applyBindings(assignmentVM, $("#assignment-data")[0]);
        ko.applyBindings(personVM, $("#persons-view")[0]);
    };
};

function findAndRemove(array, property, value) {
    $.each(array, function (index, result) {
        if (result === undefined) return;

        if (result[property] == value) {
            array.splice(index, 1);
        }
    });
}