<?php

namespace _02_Backend\BusinessManager\Principal;

require __DIR__.'/../../../_03_DataAccessLayer/Dam/PropiedadDam.php';

use _03_DataAccessLayer\Dam\PropiedadDam;

class PrincipalManager
{
    public function getPrincipalIndexInfo()
    {
        $propiedadDam = new PropiedadDam();
        return $propiedadDam->GetRandomProperties();
    }
}
