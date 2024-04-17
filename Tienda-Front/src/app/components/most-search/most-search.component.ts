import { Component } from '@angular/core';
import { Producto } from '../../models/Producto';
import { ProductoService } from '../../services/producto.service';

@Component({
  selector: 'app-most-search',
  templateUrl: './most-search.component.html',
  styleUrl: './most-search.component.css'
})
export class MostSearchComponent {

    productos: Producto[] = [];
  
    constructor(private productoService: ProductoService) { }
  
    ngOnInit(): void {
      this.productoService.getProductosMasBuscados().subscribe(productos => {
        this.productos = productos;
      });
    }
  }

