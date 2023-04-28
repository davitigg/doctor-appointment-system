import { Component, Input } from '@angular/core';
import { DoctorDto } from 'src/app/_interfaces/user/doctorDto';

@Component({
  selector: 'app-doctor-info-card',
  templateUrl: './doctor-info-card.component.html',
  styleUrls: ['./doctor-info-card.component.css'],
})
export class DoctorInfoCardComponent {
  @Input() doctor!: DoctorDto;
  descriptions = [
    { date: '2017 - დღემდე', info: 'ჩვენი კლინიკის გენერალური დირექტორი' },
    {
      date: '2002 - დღემდე',
      info: 'ჩვენი კომპიუტერული ტომოგრაფიის განყოფილების ხელმძღვანელი',
    },
    { date: '1995 - დღემდე', info: 'კარდიოლოგი / არითმოლოგი' },
  ];
}
