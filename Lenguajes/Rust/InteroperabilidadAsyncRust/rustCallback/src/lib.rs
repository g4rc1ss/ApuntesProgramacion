use std::{thread, time::Duration};

use async_std::task;

#[no_mangle]
pub fn prueba_callback(callback: fn(result: i32)) {
    let response = 4783784;

    let thread_id = thread::current().id();
    println!("Hilo de ejecucion antes del task::spawn {:?}", thread_id);

    task::spawn(async move {
        let thread_id_antes_sleep = thread::current().id();
        println!(
            "Hilo de ejecucion dentro del task::spawn {:?}",
            thread_id_antes_sleep
        );

        task::sleep(Duration::from_secs(10)).await;

        let thread_id_despues_sleep = thread::current().id();
        println!(
            "Hilo de ejecucion despues del sleep {:?}",
            thread_id_despues_sleep
        );

        // Ejecutamos el callback para indicar que la task ha terminado
        callback(response);
    });

    let thread_id_despues_spawn = thread::current().id();
    println!(
        "Hilo de ejecucion despues del task::spawn {:?}",
        thread_id_despues_spawn
    );
}
