import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';
import { Student } from 'src/app/shared/student.model';
import { StudentService } from 'src/app/shared/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {

  constructor(public service:StudentService) { }

  ngOnInit(): void {
    this.service.getStudentList();
  }

  populateForm(student: Student){    
    student.Date_Of_Birth = moment(student.Date_Of_Birth).format('yyyy-MM-DD');    
    this.service.formData = Object.assign({}, student);
  }

  deleteRecord(Id: number|null){
    if (confirm("Are you sure to delete this record?")) {
      this.service.deleteStudent(Id).subscribe(res => {
        this.service.getStudentList();
        alert("Record deleted successfully.");
      })  
    }    
  }
}
