import { Component, OnInit } from '@angular/core';

interface DataItem {
  title: string;
  description: string;
  imageUrl: string;
}

@Component({
  selector: 'app-users-grid',
  templateUrl: './users-grid.component.html',
  styleUrl: './users-grid.component.css'
})

export class UsersGridComponent implements OnInit {
  

  dataItems: DataItem[] = [
    { title: 'Card 1', description: 'Description for Card 1', imageUrl: 'https://via.placeholder.com/150' },
    { title: 'Card 2', description: 'Description for Card 2', imageUrl: 'https://via.placeholder.com/150' },
    { title: 'Special Card', description: 'Description for Special Card', imageUrl: 'https://via.placeholder.com/150' },
    // Add more items as needed
  ];

  searchTerm: string = '';

  ngOnInit(): void {
    // Initialize or fetch dataItems if needed
  }

  get filteredItems(): DataItem[] {
    return this.dataItems.filter(item =>
      item.title.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}
