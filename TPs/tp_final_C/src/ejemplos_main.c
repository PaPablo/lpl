    //busca y muestra los pacientes cuyos apellidos empiecen con T
      pac = paciente_new(); 
      size = pac->findAll(pac, &list, "apellido LIKE 'T%'");
      for(int i = 0; i < size; i++){
          pac = ((obj_paciente**)list)[i];
          printf("%-2d\t%-20s\n", i, pac->apellido);
      }


      printf("\n\n");
        obj_paciente *p = paciente_new();
     if(p->findbykey(p,38802981) != -1)
     {
         printf("Apellido y Nombre:%s – Domicilio: %s - Telefono: %s \n",p->
                 nombres, p->domicilio, p->telefono);
     }


      printf("\n\n");
      tr = turnos_new();
      //size = tr->findAll(tr, &list, NULL);

      
      //busca y muestra los turnos del 2015 que fueron asistidos, los ordena por fechahora
      

      if((size = tr->findAll(tr, &list, "to_char(turnos.fechahora, 'YYYY-MM-DD HH:MM:SS') LIKE '2015%' and turnos.asistio=1 order by fechahora")) == 0){
        printf("no se recupero nada\n");
      } else{
        printf("size: %d\n", size);
      }
      obj_paciente *pac_tr;
        
      for(i=0; i < size; i++){
          tr = ((obj_turnos**)list)[i];
          pac_tr = (obj_paciente *) tr->get_paciente(tr);
          printf("%-2d | %-15s | %-20s | %-20s | %-10d\n", 
                  i, tr->fechahora, 
                  pac_tr->apellido,
                  pac_tr->nombres,
                  pac_tr->dni);
      }


      /*      
      if((size = pac->findAll(pac, &list, NULL)) == 0) 
          printf("no recupero nada bolo\n"); // se invoca sin criterio - listar todos...
      else
          printf("%s | cantidad leida: %d\n", getFechaHora(), size);

      obj_paciente *pac_tr;
      


      for(i=0; i < size; i++)
      {
          pac = ((obj_paciente**)list)[i];
          printf("%-2d\t%-10d | %-20s | %-20s | %-20s\n", i, pac->dni, pac->apellido, pac->nombres, pac->telefono);
      }
      */

      /*
   obj_profesional *profesional;
  
   prof = profesional_new();
  if(prof->findbyid(prof, 1)!=-1)
  {	  
      printf("profesional id : %d Nombre: %s  Apellido: %s - matricula: %s\n",prof->id,prof->nombres,prof->apellido, prof->matricula);	  	  
  }
  */
/*
  os = obrasocial_new();
   if(os->findbykey(os, 1)!=-1)
  {
	  printf("Obra Social codigo : %d Nombre: %s\n",os->codigo,os->nombre);	  
  }
  
  esp = especialidad_new();
   if(esp->findbykey(esp, 1)!=-1)
  {
	  printf("Especialidad codigo : %d Nombre: %s\n",esp->codigo,esp->nombre);	  
  }
  
  pac = paciente_new();
   if(pac->findbykey(pac, 225544335)!=-1)
  {
	  printf("Paciente codigo : %d RazonSocial: %s %s\n",pac->dni,pac->apellido,pac->nombres);	  
  }
  
  ospac = paciente_obrasocial_new();
   if(ospac->findbykey(ospac, 225544335,1)!=-1)
  {
	  printf("OS Paciente dni : %d RazonSocial: %s, %s\n",ospac->dnipaciente,((obj_paciente*) ospac->get_paciente(ospac))->apellido,((obj_paciente*) ospac->get_paciente(ospac))->nombres);
  }
  */

  /*
      printf("\n");
  profesp = profesional_especialidad_new();
    size = profesp->findAll(profesp,&list,NULL); // se invoca sin criterio - listar todos...
    obj_profesional *prof_espec;
  for(i=0;i<size;++i)
  {
    profesp_o = ((obj_profesional_especialidad**)list)[i];
    prof_espec = (obj_profesional *) profesp_o->get_profesional(profesp_o);

    printf("%-3d | %-30s | %-20s | %-20s\n", i,
            prof_espec->apellido,
            prof_espec->nombres,
    ((obj_especialidad*) profesp_o->get_especialidad(profesp_o))->nombre);
  }
*/

  /*
  tr = turnos_new();
  
   if(tr->findbyfechahhmm(tr, "2017-05-10",10,15)!=-1)
  {
	  printf("%s",tr->fechahora);
  }
  */
