// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function fnListSubjects() {
    console.log("Listar Materias")
    let student_id = $("#student").val();
    console.log(student_id)

    $.ajax({
        url: "/Notes/GetSubject",
        dataType: 'json',
        type: 'POST',
        success: function (Subjects) {
            $.ajax({
                url: "/Notes/GetNotes",
                dataType: 'json',
                type: 'POST',
                data: { student_id },
                success: function (Notes) {
                    let table = $("#tableNotes tbody")
                    table.empty();
                    console.log(Notes)
                    Subjects.forEach(function (subject) {
                        let tr = $('<tr>');
                        let tdSubject = $('<td>');
                        let spamSubject = $('<span>' + subject.name + '</span>');
                        spamSubject.appendTo(tdSubject);
                        tdSubject.appendTo(tr);

                        let tdNote = $('<td>');

                       
                        
                        if (Notes.length > 0) {
                            Notes.forEach(function (note) {
                                let result = Object.keys(note);
                                const names = Object.keys(note)
                                    .filter((key) => key.includes("subject_id"))
                                    .reduce((obj, key) => {
                                        return Object.assign(obj, {
                                            [key]: note[key]
                                        });
                                    }, {});

                                if (subject.subject_id == note.subject_id) {
                                    let notef = subject.subject_id == note.subject_id ? note.note : 0;
                                    let inputNote = $('<input class="form-control" style="width:50px;" id="note_' + subject.subject_id + '" type="number" value ="' + notef + '">');
                                    inputNote.appendTo(tdNote);
                                }
                                //let notef = subject.subject_id == note.subject_id ? note.note : 0;
                                //let inputNote = $('<input class="form-control" style="width:50px;" id="note_' + subject.subject_id + '" type="number" value ="' + notef + '">');
                                //inputNote.appendTo(tdNote);
                            });
                        } else {
                            let inputNote = $('<input style="width:50px;" class="form-control" id="note_' + subject.subject_id+'" type="number">');
                            inputNote.appendTo(tdNote);
                        }

                        tdNote.appendTo(tr);

                        let tdAcction = $('<td><a href="javascript:fnSaveNote(' + subject.subject_id + ',' + student_id + ')" class =" btn btn-primary">Guardar</td>');                        

                        tdAcction.appendTo(tr);
                        tr.appendTo(table)
                        console.log(subject.name);
                    });

                }
            });
        }
    });
}

function fnSaveNote(subject_id, student_id) {
    let note = $("#note_" + subject_id).val();
    $.ajax({
        url: "/Notes/SaveNote",
        dataType: 'json',
        type: 'POST',
        data: { subject_id, student_id, note },
        success: function (data) { 
            fnListSubjects()
        }
    });

}

function filterObject(obj, callback) {
    return Object.fromEntries(Object.entries(obj).
        filter(([key, val]) => callback(val, key)));
}