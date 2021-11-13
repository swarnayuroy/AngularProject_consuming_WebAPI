import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { StudentService } from 'src/app/shared/student.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  constructor(public service: StudentService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if (form!=null)
      form.resetForm();
    this.service.formData={
      Id: null,
      FirstName: '',
      LastName: '',
      Date_Of_Birth: '',
      Gender: '',
      City: '',
      ContactNo: null,
      Grade: null
    }
  }

  onSubmit(form : NgForm){
    if (form.value.Id==null) {
      this.insertRecord(form);  
    }
    else{      
      this.updateRecord(form);
    }
  }

  insertRecord(form : NgForm){
    this.service.addStudent(form.value).subscribe(res => {
      this.resetForm(form)
      this.service.getStudentList();
      alert("Record insertion successful.");
    })
  }

  updateRecord(form : NgForm){
    this.service.updateStudent(form.value).subscribe(res => {
      this.resetForm(form)
      this.service.getStudentList();
      alert("Record updated successfully.");
    })
  }
}
