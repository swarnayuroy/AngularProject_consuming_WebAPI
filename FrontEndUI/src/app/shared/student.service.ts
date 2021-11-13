import { Injectable } from '@angular/core';
import { Student } from './student.model';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  formData: Student;
  studentList: Student[]; 
  readonly rootUrl="http://localhost:53995/api/Student";
  constructor(private http: HttpClient) { }

  addStudent(formData: Student){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post(this.rootUrl+'/AddStudent', formData, httpOptions);
  }

  getStudentList(){
    this.http.get(this.rootUrl+'/GetAllStudent').subscribe(res=>{
      this.studentList = res as Student[];
    })
  }

  updateStudent(formData: Student){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put(this.rootUrl+'/UpdateStudentDetails/' + formData.Id, formData, httpOptions);
  }

  deleteStudent(Id: number|null){
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.delete(this.rootUrl+'/RemoveStudentDetails/' + Id, httpOptions);
  }
}
