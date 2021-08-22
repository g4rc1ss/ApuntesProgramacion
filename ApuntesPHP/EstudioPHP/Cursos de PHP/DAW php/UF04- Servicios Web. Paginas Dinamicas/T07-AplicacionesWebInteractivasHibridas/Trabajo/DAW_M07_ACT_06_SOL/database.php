<?php
	class Database {
		private static $db_host = "localhost";
		private static $db_user = "linkia";
		private static $db_pass = "1234";
		private static $db_name = "google_maps";
		
		private $con;
		private $result;
		private $numRows;
		
		public function __construct(){
			$this->con = new mysqli(self::$db_host, self::$db_user, self::$db_pass, self::$db_name);
		}
		
		public function disconnect(){
			$this->con->close();
		}
		
		public function query($sql){
			$this->result = $this->con->query($sql);
			$this->numRows = $this->result->num_rows;
		}
		
		public function numRows(){
			return $this->numRows;
		}
		
		public function rows(){
			$rows = array();
			for($i=0;$i<$this->numRows;$i++){
				$rows[] = $this->result->fetch_assoc();
			}
			return $rows;
		}
	}
?>