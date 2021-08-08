<?php

namespace _02_Backend\Action\Principal;

require __DIR__.'/../../BusinessManager/Principal/PrincipalManager.php';

use _02_Backend\BusinessManager\Principal\PrincipalManager;

class PrincipalAction
{
    public function getIndexInformation()
    {
        $manager = new PrincipalManager();
        return $manager->getPrincipalIndexInfo();
    }
}
